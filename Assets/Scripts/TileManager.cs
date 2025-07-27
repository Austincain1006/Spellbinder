using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    [SerializeField] private int minSize, maxSize, numObjectives;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Camera cameraReference;
    [SerializeField] private MouseFollower mouseFollower;
    [SerializeField] public Sprite emptySprite;
    [SerializeField] public Sprite[] primalMagics;
    [SerializeField] public UserInterface ui;
    public Dictionary<string, int> inventory;
    public List<Tile> tiles;
    public List<Tile> objectives;
    public Sprite selectedSprite;
    public string selectedMagic;
    public bool doneGenerating;
    public int coins;

    void Awake()
    {
        doneGenerating = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PopulateStartingInventory();
        coins = 10;
        numObjectives = randIntInRange(3, 6);
        tiles = new List<Tile>();
        objectives = new List<Tile>();
        GenerateGrid(randIntInRange(minSize, maxSize), randIntInRange(minSize, maxSize));

    }

    void GenerateGrid(int width, int height)
    {
        // Generate Rows
        for (int x = 0; x < width; x++)
        {
            // Generate Columns
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity, this.transform);
                spawnedTile.name = $"Tile {x} {y}";
                var isOffset = (x + y) % 2 == 1;
                spawnedTile.initialize(isOffset, false);    // sets offset AND objective status
                tiles.Add(spawnedTile);
            }
        }
        makeObjectives();
        Debug.Log($"Number obj = {numObjectives}");
        doneGenerating = true;
        tiles[0].clearLines();

        cameraReference.transform.position = new Vector3(width / 2f - 0.5f, height / 2f - 0.5f, -10f);
    }

    // Unselects the currently Selected Magic Type
    public void ClearMouseFollower()
    {
        mouseFollower.Clear();
        selectedMagic = "empty";
        selectedSprite = emptySprite;
    }

    // Changes Selected Magic Type 
    public void UpdateSelectedMagic(Sprite icon, string name)
    {
        //Debug.Log($"Icon ref = {icon.name}  &  Name of Button = {name}");
        selectedSprite = icon;
        selectedMagic = name;
    }

    public bool HasMagic()
    {
        return mouseFollower.GetSprite() != emptySprite;
    }

    // Designate Special Tiles as Objectives
    void makeObjectives()
    {
        for (int i = 0; i < numObjectives; i++)
        {
            var randTile = tiles[randIntInRange(0, tiles.Count - 1)];
            if (randTile.isObjective)
            {
                i--;
                continue;
            }
            randTile.becomeObjective(primalMagics[randIntInRange(0, 5)]);
            objectives.Add(randTile);
            //Debug.Log("TileManager wants an objective!");
        }
    }

    private int randIntInRange(int min, int max)
    {
        System.Random r = new System.Random();
        return r.Next(min, max + 1);
    }

    public void WinGame()
    {
        ui.SetWinButtonVisible(true);
    }

    public void RevokeWinStatus()
    {
        ui.SetWinButtonVisible(false);
    }

    private void PopulateStartingInventory()
    {
        inventory = new Dictionary<string, int>();
        foreach (ButtonScript b in ui.magicBoard.getButtons())
        {
            inventory.Add(b.magicImage.sprite.name, 5);
            print($"DICTIONARY: {b.magicImage.sprite.name}   -> maps into {inventory[b.magicImage.sprite.name]}");
        }
    }

    public void addMagic(string magicType, int amount)
    {
        print($"Adding {amount} to {magicType}");
        inventory[magicType] += amount;
        ui.magicBoard.updateButtonText(magicType, inventory[magicType].ToString());
    }

    public void addCoins(int amount)
    {
        coins += amount;
        
    }
}




