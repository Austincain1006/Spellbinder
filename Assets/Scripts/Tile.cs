using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, accentColor;
    [SerializeField] private SpriteRenderer myRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private SpriteRenderer magicIcon;
    private bool isHighlighted;
    
    

    private bool updateColor = false;



    public void initialize(bool isOffset)
    {
        updateColor = isOffset;
        myRenderer.color = (isOffset) ? accentColor : baseColor;
    }


    void Start()
    {
        tileManager = GetComponentInParent<TileManager>();
    }

    void Update()
    {
        myRenderer.color = (updateColor) ? accentColor : baseColor;
    }

    void OnMouseEnter()
    {
        UpdateHighlight(true);
        //Debug.Log("Enter!");
        highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        UpdateHighlight(false);
        //Debug.Log("Exit!");
        highlight.SetActive(false);
    }

    void UpdateHighlight(bool highlight)
    {
        this.isHighlighted = highlight;
        
    }

    void OnMouseDown()
    {
        //Debug.Log($"clicked on {name}!");

        //GetComponent<SpriteRenderer>().sprite = tileManager.selectedSprite;
        magicIcon.GetComponent<SpriteRenderer>().sprite = tileManager.selectedSprite;
        tileManager.ClearMouseFollower();
    }
}
