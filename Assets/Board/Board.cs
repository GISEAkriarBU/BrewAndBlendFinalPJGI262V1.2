using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject cellPrefab;  // assign prefab in Inspector
    public int gridSizeX = 3;
    public int gridSizeY = 3;
    public float cellSpacing = 1f;

    private Cell[,] cells;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        cells = new Cell[gridSizeX, gridSizeY];

        float offsetX = (gridSizeX - 1) * cellSpacing * 0.5f;
        float offsetY = (gridSizeY - 1) * cellSpacing * 0.5f;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 pos = new Vector3(x * cellSpacing - offsetX, y * cellSpacing - offsetY, 0f);
                GameObject go = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
                Cell cell = go.GetComponent<Cell>();
                if (cell != null)
                {
                    cell.SetBoardPosition(x, y);
                    cells[x, y] = cell;
                }
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        return cells[x, y];
    }
}

