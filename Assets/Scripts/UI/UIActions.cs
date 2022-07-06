using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActions : MonoBehaviour
{

    private bool isRaidPickerPanelActive;
    private bool isInventoryActive;
    private ZraidersSceneManager zsm;

    [SerializeField]
    private CanvasGroup raidPickerPanelCanvasGroup; //add in editor

    [SerializeField]
    private CanvasGroup inventoryPanelCanvasGroup; //add in editor

    void Start()
    {

        isRaidPickerPanelActive = false;
        zsm = GameObject.FindGameObjectWithTag(GameObjectTags.SCENE_MANAGER).GetComponent(typeof (ZraidersSceneManager)) as ZraidersSceneManager;
    }

    public void OpenInventory()
    {
        ToggleInventoryPanelCanvasGroup();
    }

    public void ToggleInventoryPanelCanvasGroup(bool isStartCall = false)
    {
        inventoryPanelCanvasGroup.alpha = isInventoryActive ? 0 : 1;
        inventoryPanelCanvasGroup.interactable = !isInventoryActive;
        isInventoryActive = !isInventoryActive;
    }

    public void ToggleRaidPanelCanvasGroup(bool isStartCall = false)
    {
        InventoryPayload ip = new InventoryPayload(ItemDatabaseSingleton.Instance.GetItemById(0), 0);
        (GameObject.FindGameObjectWithTag(GameObjectTags.INVENTORY_MANAGER).GetComponent(typeof (InventoryManager)) as InventoryManager).Notify(ip);

        InventoryPayload ip2 = new InventoryPayload(ItemDatabaseSingleton.Instance.GetItemById(1), 1);
        (GameObject.FindGameObjectWithTag(GameObjectTags.INVENTORY_MANAGER).GetComponent(typeof (InventoryManager)) as InventoryManager).Notify(ip2);
        raidPickerPanelCanvasGroup.alpha = isRaidPickerPanelActive ? 0 : 1;
        raidPickerPanelCanvasGroup.interactable = !isRaidPickerPanelActive;
        isRaidPickerPanelActive = !isRaidPickerPanelActive;
    }

    public void ToggleRaidPicker()
    {
        ToggleRaidPanelCanvasGroup();
    }

    public void StartRaid(int raidSettings = -1)
    {
        zsm.LoadRaid();
    }

    public void ReturnToBase()
    {
        zsm.LoadBase();
    }

    public void StartGame()
    {
        zsm.LoadGame();
    }
}
