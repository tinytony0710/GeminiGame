using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;

    private bool[,] grid;

    public GameObject gridCellPrefab;
    public float gridSpacing = 1f;

    private void Start()
    {
        grid = new bool[gridSizeX, gridSizeY];
        // Create a 10x10 grid of grid cells
        for(int x = 0 ; x < 10 ; x++)
        {
            for(int y = 0 ; y < 10 ; y++)
            {
                Vector3 gridPosition = new Vector3(x * gridSpacing, 0f, y * gridSpacing);
                Instantiate(gridCellPrefab, gridPosition, Quaternion.identity);
            }
        }
    }

    public bool CheckGridAvailability(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.z);

        if(x >= 0 && x < gridSizeX && y >= 0 && y < gridSizeY)
        {
            return !grid[x, y];
        }

        return false;
    }

    public void PlaceBuildingOnGrid(BuildingData buildingData, Vector3 gridPosition)
    {
        int x = Mathf.RoundToInt(gridPosition.x);
        int y = Mathf.RoundToInt(gridPosition.z);

        if(CheckGridAvailability(gridPosition))
        {
            // Mark grid cell as occupied
            grid[x, y] = true;
        }
    }

    public void MarkGridCellAsOccupied(Vector3 gridPosition)
    {
        int x = Mathf.RoundToInt(gridPosition.x);
        int y = Mathf.RoundToInt(gridPosition.z);

        if(x >= 0 && x < gridSizeX && y >= 0 && y < gridSizeY)
        {
            grid[x, y] = true;
        }
    }

    public void MarkGridCellAsUnoccupied(Vector3 gridPosition)
    {
        int x = Mathf.RoundToInt(gridPosition.x);
        int y = Mathf.RoundToInt(gridPosition.z);

        if(x >= 0 && x < gridSizeX && y >= 0 && y < gridSizeY)
        {
            grid[x, y] = false;
        }
    }
}
