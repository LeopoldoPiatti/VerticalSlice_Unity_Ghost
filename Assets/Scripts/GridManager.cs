using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSize = 10;      // Tamaño de la grilla
    public float cellSize = 1f;    // Tamaño de cada celda
    public Material gridMaterial;   // Material para las líneas
    public float lineWidth = 0.1f;  // Ancho de las líneas

    void Start()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                DrawLine(new Vector3(x * cellSize, 0, z * cellSize), new Vector3(x * cellSize, 0, (z + 1) * cellSize));
                DrawLine(new Vector3(x * cellSize, 0, z * cellSize), new Vector3((x + 1) * cellSize, 0, z * cellSize));
            }
        }

        // Dibujar las líneas del último borde
        DrawLine(new Vector3(gridSize * cellSize, 0, 0), new Vector3(gridSize * cellSize, 0, gridSize * cellSize));
        DrawLine(new Vector3(0, 0, gridSize * cellSize), new Vector3(gridSize * cellSize, 0, gridSize * cellSize));
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject line = new GameObject("GridLine");
        line.transform.parent = transform;

        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new Vector3[] { start, end });

        // Asignar el material al LineRenderer
        lineRenderer.material = gridMaterial;

        // Ajustar el ancho de las líneas
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }
}


