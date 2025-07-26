using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, accentColor;
    [SerializeField] private SpriteRenderer myRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private SpriteRenderer magicIcon;
    private bool updateColor = false;


    // Used by Tilemanager to set initial conditions of Tile
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
        magicIcon.GetComponent<SpriteRenderer>().sprite = tileManager.selectedSprite;
        tileManager.ClearMouseFollower();
    }
}
