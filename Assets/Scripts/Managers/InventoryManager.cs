using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IObservable<InventoryPayload>
{
    public InventorySystem inventorySystem;

    List<IObserver<InventoryPayload>> _observers;

    public List<UIInventorySlot> UIslots { get; set; }

    void Awake()
    {
        _observers = new List<IObserver<InventoryPayload>>();
        inventorySystem = DataManagerSingleton.Instance.inventorySystem;
    }

    //if not provided a slot id, inserts in first empty slot
    public void AddItemById(int id)
    {
        Item i = ItemDatabaseSingleton.Instance.GetItemById(id);
        if (i != null)
        {
            //check first empty inventory slot
            int firstEmptySlot = FirstEmptyInventorySlot();
            if (firstEmptySlot >= 0)
            {
                inventorySystem.AddItem(i, firstEmptySlot);
                InventoryPayload ip = new InventoryPayload(i, firstEmptySlot);
                Notify(ip);
            }
        }
    }

    public void AddItemById(int id, int slotId)
    {
        Item i = ItemDatabaseSingleton.Instance.GetItemById(id);
        if (i != null)
        {
            inventorySystem.AddItem(i, slotId);
            InventoryPayload ip = new InventoryPayload(i, slotId);
            Notify(ip);
        }
    }

    private int FirstEmptyInventorySlot()
    {
        int idx = UIslots.FindIndex(slot => slot.item == null);
        return idx;
    }

    public void AddItem(Item item)
    {
        int firstEmptySlot = FirstEmptyInventorySlot();
        if (firstEmptySlot >= 0)
        {
            inventorySystem.AddItem(item, firstEmptySlot);
            InventoryPayload ip = new InventoryPayload(item, firstEmptySlot);
            Notify(ip);
        }
    }

    public void AddItem(Item item, int slotId)
    {

        inventorySystem.AddItem(item, slotId);
        InventoryPayload ip = new InventoryPayload(item, slotId);
        Notify(ip);

    }

    public void RemoveItem(int index)
    {
        inventorySystem.RemoveItem(index);
        InventoryPayload ip = new InventoryPayload(null, index);
        Notify(ip);
    }

    public void Attach(IObserver<InventoryPayload> observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver<InventoryPayload> observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(InventoryPayload payload)
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(payload);
        }
    }
}
