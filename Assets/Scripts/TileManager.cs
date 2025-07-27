using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Camera cameraReference;
    [SerializeField] private MouseFollower mouseFollower;
    [SerializeField] public Sprite emptySprite;
    [SerializeField] public Sprite[] primalMagics;

    private int numObjectives;
    public List<Tile> tiles;
    public List<Tile> objectives;
    public Sprite selectedSprite;
    public string selectedMagic;
    public bool doneGenerating;

    void Awake()
    {
        doneGenerating = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numObjectives = 6;
        tiles = new List<Tile>();
        objectives = new List<Tile>();
        GenerateGrid();

    }

    void GenerateGrid()
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
        doneGenerating = true;

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

    
}




