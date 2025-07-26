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
        ChangeSprite(emptySprite);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(mousePos.x, mousePos.y, this.transform.position.z);

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            ChangeSprite(emptySprite);
        }
    }

    public void ChangeSprite(Sprite s)
    {
        sprite = s;
        GetComponent<SpriteRenderer>().sprite = s;
    }

    public void Clear()
    {
        ChangeSprite(emptySprite);
    }

}
