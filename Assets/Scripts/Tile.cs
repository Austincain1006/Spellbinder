using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, accentColor;
    [SerializeField] private SpriteRenderer myRenderer;
    [SerializeField] private GameObject highlight;
    

    private bool updateColor = false;



    public void initialize(bool isOffset)
    {
        updateColor = isOffset;
        myRenderer.color = (isOffset) ? accentColor : baseColor;
    }


    void Update()
    {
        myRenderer.color = (updateColor) ? accentColor : baseColor;
    }

    void OnMouseEnter()
    {
        //Debug.Log("Enter!");
        highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        //Debug.Log("Exit!");
        highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        //Debug.Log($"clicked on {name}!");
    }
}
