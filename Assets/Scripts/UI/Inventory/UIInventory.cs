using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour, IObserver<InventoryPayload>
{
    public List<GameObject> slots;
    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private GridLayoutGroup inventoryGridUI;

    private Transform inventoryGridUITransform;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Awake()
    {
        slots = new List<GameObject>();
        //load resource for prefab?
        
        inventoryManager = GameObject.FindGameObjectWithTag(GameObjectTags.INVENTORY_MANAGER).GetComponent(typeof (InventoryManager)) as InventoryManager;
        inventoryManager.Attach(this);
        //draw all prefabs
    }

    void Start()
    {
        inventoryGridUI = GetComponentInChildren<GridLayoutGroup>();
        inventoryGridUITransform = inventoryGridUI.transform;

        //instantiate
        for(int i = 0; i < inventoryManager.inventorySystem.slots; i++)
        {
            slots.Add(Instantiate(slotPrefab, inventoryGridUITransform));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        inventoryManager.Detach(this);
        //doesn't work for some godforsaken reason

    }

    public void OnNotify(InventoryPayload payload)
    {
        if (payload.inventorySlot < slots.Count)
        {
            (slots[payload.inventorySlot].GetComponent<UIInventorySlot>() as UIInventorySlot).UpdateItem(payload.item);
        }
    }
}
