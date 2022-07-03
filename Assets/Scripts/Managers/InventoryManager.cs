using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IObservable<InventoryPayload>
{
    public InventorySystem inventorySystem;

    List<IObserver<InventoryPayload>> _observers;

    // Start is called before the first frame update

    void Awake()
    {
        _observers = new List<IObserver<InventoryPayload>>();
        inventorySystem = DataManagerSingleton.Instance.inventorySystem;
    }

    void Start()
    {
        
    }

    public void AddItem(ItemDefinition iDef)
    {
        inventorySystem.AddItem(iDef);
    }

    public void RemoveItem(int index)
    {
        inventorySystem.RemoveItem(index);
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
