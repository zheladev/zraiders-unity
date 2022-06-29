using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    public float maxZoom = 1;
    public float minZoom =5;
    public float sensitivity = 1;
    public float speed =30;
    float targetZoom;

    void Start()
    {  
        cam = this.GetComponent<Camera>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speed * Time.deltaTime);
        cam.orthographicSize = newSize;
    }
}
