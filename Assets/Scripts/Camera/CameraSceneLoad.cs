using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // Update is called once per frame
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        transform.position =  new Vector3(0f, 0f, transform.position.z);
    }
}
