using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, accentColor;
    [SerializeField] private SpriteRenderer myRenderer;

    private bool tempDebug = false;

    public void initialize(bool isOffset)
    {
        Debug.Log(isOffset);
        tempDebug = isOffset;
        myRenderer.color = (isOffset) ? accentColor : baseColor;
    }


    void Update()
    {
        myRenderer.color = (tempDebug) ? accentColor : baseColor;
    }
}
