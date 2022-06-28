using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActions : MonoBehaviour
{
    private ZraidersSceneManager zsm;

    void Start()
    {
        zsm = GameObject.FindGameObjectWithTag(GameObjectTags.SCENE_MANAGER).GetComponent(typeof (ZraidersSceneManager)) as ZraidersSceneManager;
        Debug.Log(zsm);
    }

    public void OpenInventory()
    {
        //todo
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
