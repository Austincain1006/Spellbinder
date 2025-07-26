using Microsoft.Unity.VisualStudio.Editor;
using Mono.Cecil;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{

    private Vector3 mousePos;
    [SerializeField] Camera cam;
    public Sprite sprite;
    [SerializeField] private Sprite emptySprite;

    void Start()
    {
        Clear();
    }

    // Update is called once per frame
    void Update()
    {
        PlaceFollowerOntoMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Clear();
        }


        
    }

    // Change Magic Icon
    public void ChangeSprite(Sprite s)
    {
        sprite = s;
        GetComponent<SpriteRenderer>().sprite = s;
    }

    // Remove Icon from Player's Mouse
    public void Clear()
    {
        ChangeSprite(emptySprite);
    }

    // Make a Magic Icon Follow the Player's Mouse
    void PlaceFollowerOntoMouse()
    {
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(mousePos.x, mousePos.y, this.transform.position.z);
    }


    public Sprite GetSprite()
    {
        return sprite;
    }

}
