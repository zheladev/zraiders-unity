using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActions : MonoBehaviour
{

    private bool isRaidPickerPanelActive;
    private ZraidersSceneManager zsm;

    [SerializeField]
    private CanvasGroup raidPickerPanelCanvasGroup; //add in editor
    void Start()
    {

        isRaidPickerPanelActive = false;
        zsm = GameObject.FindGameObjectWithTag(GameObjectTags.SCENE_MANAGER).GetComponent(typeof (ZraidersSceneManager)) as ZraidersSceneManager;
        Debug.Log(zsm);
    }

    public void OpenInventory()
    {
        //todo
    }

    public void ToggleRaidPanelCanvasGroup(bool isStartCall = false)
    {
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
