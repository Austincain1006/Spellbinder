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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseDown();  // hacky bugfix for RMB not working
        }
    }

    void OnMouseEnter()
    {
        
        highlight.SetActive(true);
        
        
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        Sprite selectedSprite = tileManager.selectedSprite;
        Debug.Log("CLICK");

        if (Input.GetMouseButtonDown(1))        // Clear Tile if Player clicks RMB
        {
            Debug.Log("RMB");

            magicIcon.sprite = tileManager.emptySprite;
            
            tileManager.ClearMouseFollower();
        }
        else if (Input.GetMouseButtonDown(0) && selectedSprite != tileManager.emptySprite)   // Place Tile if Player clicks LMB
        {
            magicIcon.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            tileManager.ClearMouseFollower();
            Debug.Log("LMB");
        }
        
    }
}
