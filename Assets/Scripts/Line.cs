using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Debug.Log($"{lineRenderer} is probably null");
    }

    public void ConnectLine(Vector3 start, Vector3 end)
    {
        Debug.Log($"Connecting {start} and {end}");

        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(0, end);
    }

    public void Clear()
    {
        lineRenderer.positionCount = 0;
    }
}
