using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, accentColor;
    [SerializeField] private SpriteRenderer myRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private SpriteRenderer magicIcon;
    private List<Tile> neighbors;
    [SerializeField] private Line[] lines;
    private bool updateColor = false;

    // Used by Tilemanager to set initial conditions of Tile
    public void initialize(bool isOffset)
    {
        updateColor = isOffset;
        myRenderer.color = (isOffset) ? accentColor : baseColor;
    }

    void Start()
    {
        //lines = GetComponentsInChildren<Line>();
        //Debug.Log($"{lines} is null isnt it; but what about {lines[7]} and {lines[6]}");
        tileManager = GetComponentInParent<TileManager>();
        neighbors = new List<Tile>();
        getNeighbors();
        connectNeighbors();
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


        if (Input.GetMouseButtonDown(1))        // Clear Tile if Player clicks RMB
        {
            magicIcon.sprite = tileManager.emptySprite;
            tileManager.ClearMouseFollower();
        }
        else if (Input.GetMouseButtonDown(0) && selectedSprite != tileManager.emptySprite)   // Place Tile if Player clicks LMB
        {
            magicIcon.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            tileManager.ClearMouseFollower();
            connectNeighbors();
        }

    }

    // Populate neighbors with list of all nearby Tiles
    void getNeighbors()
    {
        foreach (var n in tileManager.tiles)
        {
            // Do not include self in Neighbors
            if (n == this)
            {
                continue;
            }

            float distance = (this.transform.position - n.transform.position).magnitude;
            if (distance < 1.1f && distance != 0f)
            {
                this.neighbors.Add(n);
            }
        }

        //Debug.Log($"Tile {this.name}'s neighbors are {printList(neighbors)}");
    }

    // Debug Function to print neighbors
    string printList(List<Tile> l)
    {
        string result = "";
        foreach (var x in l)
        {
            result += x.name + ", ";
        }
        return result;
    }

    void connectNeighbors()
    {

        int i = 0;
        foreach (var n in neighbors)
        {
            if (i > 7)
            {
                break;
            }

            /*
            if (n.magicIcon.sprite.name != "empty_0")
            {
                Debug.Log($"{n}");
                lines[i].ConnectLine(this.transform.position, n.transform.position);
            }
            */
            
            if (isMagicEqual(this.magicIcon.sprite.name, n.magicIcon.sprite.name))
            {
                Debug.Log($"Comparing {this.magicIcon.sprite.name} to {n.magicIcon.sprite.name}");
                lines[i].ConnectLine(this.transform.position, n.transform.position);
            }
    
            i++;
        }

    }

    bool isMagicEqual(string x, string y)
    {
        string X = decomposeMagic(x);
        string Y = decomposeMagic(y);

        if (X == null || Y == null || x == y)
        {
            return false;
        }

        char a = X[0];
        char b = X[1];
        char c = Y[0];
        char d = Y[1];

        return a == c || a == d || b == c || b == d;
    }

    // Return the Two primal magics that make up an element
    string decomposeMagic(string s)
    {
        // Order = O
        // Chaos = C
        // Fire = F
        // Water = W
        // Earth = E
        // Air = A
        switch (s)
        {
            case "empty_0":
                return null;
            case "MagicBalance_0":
                return "OC";
            case "MagicCrystal_0":
                return "OE";
            case "MagicEarthquake_0":
                return "EC";
            case "MagicEnergy_0":
                return "OF";
            case "MagicExplosion_0":
                return "CF";
            case "MagicIce_0":
                return "OW";
            case "MagicLife_0":
                return "EW";
            case "MagicMagma_0":
                return "EF";
            case "MagicMovement_0":
                return "OA";
            case "MagicSand_0":
                return "EA";
            case "MagicSpace_0":
                return "WC";
            case "MagicSteam_0":
                return "WF";
            case "MagicStorm_0":
                return "AF";
            case "MagicTornado_0":
                return "AC";
            case "MagicErosion_0":
                return "EA";
            case "MagicRain_0":
                return "AW";
            default:
                Debug.LogError($"DECOMPOSE MAGIC FOR {s} IS FUCKED");
                return null;
        }

    }

}
