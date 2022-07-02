using System.Collections.Generic;
using UnityEngine;

//May be redundant
public class InventoryManager : MonoBehaviour, ISubject
{
    public InventorySystem inventorySystem;

    List<IObserver> _observers;

    // Start is called before the first frame update

    void Awake()
    {
        _observers = new List<IObserver>();
        inventorySystem = DataManagerSingleton.Instance.inventorySystem;
    }

    void Start()
    {
        Debug.Log(inventorySystem);
        Notify();
    }

    public void AddItem(ItemDefinition iDef)
    {
        inventorySystem.AddItem(iDef);
    }

    public void RemoveItem(int index)
    {
        inventorySystem.RemoveItem(index);
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(this);
        }
    }
}
