using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Camera cameraReference;
    [SerializeField] private MouseFollower mouseFollower;
    [SerializeField] private Sprite emptySprite;
    
    public Sprite selectedSprite;
    public string selectedMagic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity, this.transform);
                spawnedTile.name = $"Tile {x} {y}";
                var isOffset = (x + y) % 2 == 1;
                spawnedTile.initialize(isOffset);
            }
        }

        cameraReference.transform.position = new Vector3(width / 2f - 0.5f, height / 2f - 0.5f, -10f);
    }


    public void ClearMouseFollower()
    {
        Debug.Log("Tilemanger runs");
        mouseFollower.Clear();
        selectedMagic = "empty";
        selectedSprite = emptySprite;
    }

    public void UpdateSelectedMagic(Sprite icon, string name)
    {
        Debug.Log($"Icon ref = {icon.name}  &  Name of Button = {name}");
        selectedSprite = icon;
        selectedMagic = name;
    }
}




