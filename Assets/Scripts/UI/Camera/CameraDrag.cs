using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 0.35f;
    private Vector3 dragOrigin;
    private bool isDragging;

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(-Input.GetAxisRaw("Mouse X") * dragSpeed, -Input.GetAxisRaw("Mouse Y") * dragSpeed, 0f);
        }
    }
}
