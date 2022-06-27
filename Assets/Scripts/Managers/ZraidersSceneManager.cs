using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZraidersSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //do random shit before loading scenes
        Debug.Log("test");
        LoadGame();
    }

    public void LoadGame()
    {
        LoadAdditively(Scenes.UI_SCENE);
        LoadAdditively(Scenes.BASE_SCENE);
    }

    public void LoadBase()
    {
        List<string> scenesToKeepAlive = new List<string>();
        BulkUnload(scenesToKeepAlive);
        LoadAdditively(Scenes.BASE_SCENE);
    }

    public void LoadRaid()
    {
        List<string> scenesToKeepAlive = new List<string>();
        BulkUnload(scenesToKeepAlive);
        LoadAdditively(Scenes.RAID_SCENE);
    }

    void LoadAdditively(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

    void Load(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void BulkUnload(List<string> keepAlive, bool removeUI = false)
    {
        
        //never unload game manager scene
        keepAlive.Add(Scenes.GAME_MANAGER);

        if (!removeUI) {
            keepAlive.Add(Scenes.UI_SCENE);
        }
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene s = SceneManager.GetSceneAt(i);
            if (!keepAlive.Contains<string>(s.name))
            {
                Unload(s);
            }
        }
    }

    void Unload(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }

    void Unload(Scene scene) 
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
