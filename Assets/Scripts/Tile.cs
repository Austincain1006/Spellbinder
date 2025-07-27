using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, accentColor, objectiveColor;
    [SerializeField] private SpriteRenderer myRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private SpriteRenderer magicIcon;
    private List<Tile> neighbors;

    [SerializeField] private Line[] lines;
    private bool updateColor = false;
    public bool isObjective;

    // Used by Tilemanager to set initial conditions of Tile
    public void initialize(bool isOffset, bool isObjective)
    {
        this.isObjective = isObjective;
        updateColor = isOffset;

        if (isObjective)
        {
            myRenderer.color = objectiveColor;
        }
        else
        {
            myRenderer.color = (isOffset) ? accentColor : baseColor;
        }
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

        if (isObjective)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))        // Clear Tile if Player clicks RMB
        {
            magicIcon.sprite = tileManager.emptySprite;
            tileManager.ClearMouseFollower();
            // Break line connections when erasing nodes
            if (tileManager.doneGenerating)
            {
                foreach (var n in neighbors)
                {
                    n.updateTile();
                }
            }
            if (!IsAtWinState(this))
            {
                tileManager.RevokeWinStatus();
                Debug.Log("nvm u dont win anymore lol");
            }
        }
        else if (Input.GetMouseButtonDown(0) && selectedSprite != tileManager.emptySprite)   // Place Tile if Player clicks LMB
        {
            magicIcon.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            tileManager.ClearMouseFollower();
            if (IsAtWinState(this))
            {
                tileManager.WinGame();
                Debug.Log("HOLY MOLY YOU WON!");
            }

        }

        connectNeighbors();
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
            lines[i].Clear();

            if (i > 3)
            {
                break;
            }



            if (isMagicEqual(this.magicIcon.sprite.name, n.magicIcon.sprite.name))
            {
                //Debug.Log($"Comparing {this.magicIcon.sprite.name} to {n.magicIcon.sprite.name}");
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
            case "Magic Air_0":
                return "AA";
            case "MagicChaos_0":
                return "CC";
            case "MagicEarth_0":
                return "EE";
            case "MagicFire_0":
                return "FF";
            case "MagicOrder_0":
                return "OO";
            case "MagicWater_0":
                return "WW";
            default:
                Debug.LogError($"DECOMPOSE MAGIC FOR {s} IS NONEXISTANT");
                return null;
        }//end switch

    }// decomposeMagic

    public void becomeObjective(Sprite s)
    {
        this.isObjective = true;
        baseColor = objectiveColor;
        accentColor = objectiveColor;
        myRenderer.color = objectiveColor;
        //Debug.Log("I am now an objective!");

        magicIcon.GetComponent<SpriteRenderer>().sprite = s;

    }

    void updateTile()
    {
        connectNeighbors();
    }


    // Check if Board in a Win Condition
    bool IsAtWinState(Tile startingTile)
    {
        int objectivesComplete = 0;
        // Run DFS, check if OBJECTIVE number of is in visited stack
        foreach (Tile t in DFS(startingTile))
        {
            if (t.isObjective)
            {
                objectivesComplete++;
            }

            if (objectivesComplete >= tileManager.objectives.Count)
            {
                Debug.Log($"Checking if {objectivesComplete} >= {tileManager.objectives.Count}");
                return true;
            }

        }

        return false;
    }

    Stack<Tile> DFS(Tile startingTile)
    {
        Stack<Tile> visited = new Stack<Tile>(); // Visited Nodes

        foreach (Tile n in startingTile.neighbors)
        {
            if (!visited.Contains(n) && n.magicIcon.sprite.name != "empty_0" &&
            isMagicEqual(startingTile.magicIcon.sprite.name, n.magicIcon.sprite.name))
            {
                isMagicEqual(startingTile.magicIcon.sprite.name, n.magicIcon.sprite.name);
                DFSVisit(visited, startingTile);
            }

        }

        //Debug.Log($"Visited = {visited}");
        //printStack(visited);
        return visited;
    }

    void DFSVisit(Stack<Tile> visited, Tile currentTile)
    {
        visited.Push(currentTile);
        foreach (Tile n in currentTile.neighbors)
        {
            if (!visited.Contains(n) && n.magicIcon.sprite.name != "empty_0"
            && isMagicEqual(currentTile.magicIcon.sprite.name, n.magicIcon.sprite.name))
            {
                
                DFSVisit(visited, n);
            }
        }
    }

    void printStack(Stack<Tile> s)
    {
        int i = 0;
        string result = "";
        foreach (Tile t in s)
        {
            result += $"{i} : ";
            result += t.name;
            result += ",   ";
            i++;
        }
        print(result);
    }

    public void clearLines()
    {
        foreach (var l in lines)
        {
            l.Clear();
        }
    }
}
