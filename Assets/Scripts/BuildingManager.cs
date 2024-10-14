using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    public List<Building> buildings = new List<Building>();
    public GridManager gridManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool CheckGridAvailability(Vector3 gridPosition)
    {
        return gridManager.CheckGridAvailability(gridPosition);
    }

    public void BuildBuilding(BuildingData buildingData, Vector3 gridPosition)
    {
        if(CheckGridAvailability(gridPosition))
        {
            Debug.Log("CheckGridAvailability(gridPosition)");
            //if(gridManager.CheckGridAvailability(GetGridPositionFromWorldPosition(buildingData.placementRule)))
            //{
            //Debug.Log("gridManager.CheckGridAvailability(GetGridPositionFromWorldPosition(buildingData.placementRule)))");
            if(CheckPlacementValidity(buildingData.placementRule, buildingData.cost))
            {
                Debug.Log(gridPosition);
                // Instantiate the building prefab
                GameObject buildingGameObject = Instantiate(buildingData.prefab, gridPosition, Quaternion.identity);

                Debug.Log("Building GameObject instantiated at: " + buildingGameObject.transform.position);
                // Create a new Building instance
                Building building = buildingGameObject.GetComponent<Building>();
                if(building == null)
                {
                    building = buildingGameObject.AddComponent<Building>();
                }

                // Assign building data and grid position
                building.buildingData = buildingData;
                building.gridPosition = GetGridPositionFromWorldPosition(buildingData.placementRule);

                // Add the building to the list
                buildings.Add(building);

                // Update grid availability
                gridManager.MarkGridCellAsOccupied(GetGridPositionFromWorldPosition(buildingData.placementRule));
                gridManager.PlaceBuildingOnGrid(buildingData, GetGridPositionFromWorldPosition(buildingData.placementRule));
            }
            //}
        }
    }

    public bool CheckPlacementValidity(PlacementRule placementRule, int cost)
    {
        // Implement logic to check if the building can be placed based on the placement rule and resource availability
        // For example, you can check if the grid cell is unoccupied and if the player has enough resources
        return true; // Replace with your actual logic
    }

    public void UpdateBuildingResources()
    {
        foreach(Building building in buildings)
        {
            // Update the building's resource production and consumption
            building.UpdateResources();
        }
    }

    public void RemoveBuilding(BuildingData buildingData)
    {
        // Find the building in the list
        Building buildingToRemove = buildings.Find(b => b.buildingData == buildingData);

        if(buildingToRemove != null)
        {
            // Remove the building from the list
            buildings.Remove(buildingToRemove);

            // Update grid availability
            gridManager.MarkGridCellAsUnoccupied(GetGridPositionFromWorldPosition(buildingData.placementRule));

            // Refund resources (if applicable)
            // ...
        }
    }

    private Vector3 GetGridPositionFromWorldPosition(PlacementRule placementRule)
    {
        // Implement logic to convert a world position to a grid position based on the placement rule
        return Vector3.zero; // Replace with your actual logic
    }
}
