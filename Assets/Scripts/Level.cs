using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    [SerializeField] float cellSize = 4;

    List<GameObject> cells;

    public void Make(int width, int height)
    {
        Blueprint blueprint = new Blueprint(width, height);
        cells = new List<GameObject>();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 pos = new Vector3(j * cellSize, i * cellSize, 0);
                GameObject cell = Instantiate(cellPrefab, pos, Quaternion.identity);
                cell.GetComponent<CellGraphic>().CellData = blueprint.Cells[i * width + j];
                cells.Add(cell);
            }
        }
    }

    public void Delete()
    {
        if (cells != null)
        {
            foreach (GameObject cell in cells)
                Destroy(cell);
            cells.Clear();
        }
    }
}