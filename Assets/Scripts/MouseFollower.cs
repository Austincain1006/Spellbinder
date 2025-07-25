using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{

    private Vector3 mousePos;
    [SerializeField] Camera cam;

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(mousePos.x, mousePos.y, this.transform.position.z);
    }

    void changeImage(Sprite s)
    {
        GetComponent<SpriteRenderer>().sprite = s;
    }
}
