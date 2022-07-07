using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour, IObserver<InventoryPayload>
{
    public List<UIInventorySlot> slots;
    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private GridLayoutGroup inventoryGridUI;

    private Transform inventoryGridUITransform;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Awake()
    {
        slots = new List<UIInventorySlot>();
        //load resource for prefab?
        
        inventoryManager = GameObject.FindGameObjectWithTag(GameObjectTags.INVENTORY_MANAGER).GetComponent(typeof (InventoryManager)) as InventoryManager;
        inventoryManager.Attach(this);
    }

    void Start()
    {
        inventoryGridUI = GetComponentInChildren<GridLayoutGroup>();
        inventoryGridUITransform = inventoryGridUI.transform;

        //instantiate slots
        for(int i = 0; i < inventoryManager.inventorySystem.slots; i++)
        {
            UIInventorySlot uislot = Instantiate(slotPrefab, inventoryGridUITransform).GetComponentInChildren<UIInventorySlot>() as UIInventorySlot;
            uislot.slotId = i;
            uislot.inventoryManager = inventoryManager;
            slots.Add(uislot);
        }

        //pass slot list to manager
        inventoryManager.UIslots = slots;
    }

    void OnDestroy()
    {
        inventoryManager.Detach(this);

    }

    public void OnNotify(InventoryPayload payload)
    {
        if (payload.inventorySlot < slots.Count)
        {
            slots[payload.inventorySlot].UpdateItem(payload.item);
        }
    }
}
