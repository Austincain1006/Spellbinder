using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector3 dragOrigin;
    public bool isEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            panCamera();
        }
        
    }

    // Move Camera when Player Clicks and Drags Mouse
    private void panCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }
    }
}
