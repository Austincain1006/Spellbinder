using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        
    }

    public void ConnectLine(Vector3 start, Vector3 end)
    {
        Debug.Log($"Connecting {start} and {end}");
        start = new Vector3(start.x, start.y, -5);
        end = new Vector3(end.x, end.y, -5);

        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    public void Clear()
    {
        lineRenderer.positionCount = 0;
    }
}
