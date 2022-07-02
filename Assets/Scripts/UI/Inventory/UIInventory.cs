using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour, IObserver
{
    public List<UIInventorySlot> slots = new List<UIInventorySlot>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    
    private InventorySystem inventorySystem;

    // Start is called before the first frame update
    void Awake()
    {
        DataManagerSingleton.Instance.inventorySystem.AddItem(ItemDatabaseSingleton.Instance.GetItemById(0));
        //draw all prefabs
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(DataManagerSingleton.Instance.inventorySystem.items);
    }

    void OnDestroy()
    {
        
    }

    public void OnNotify(ISubject subject)
    {
        Debug.Log("Lol notified");
    }
}
