using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Wood,
    Stone,
    Food,
    Money
}

public enum PlacementRule
{
    Anywhere,
    OnRoad,
    NearWater,
    OnFlatGround
}

public class BuildingData
{
    public int cost;
    public int resourceProduction;
    public int resourceConsumption;
    public ResourceType provides;
    public PlacementRule placementRule;
    public string name;
    public GameObject prefab;

    public static BuildingData House = new BuildingData()
    {
        cost = 100,
        resourceProduction = 10, // Produces 10 money per unit time
        resourceConsumption = 5, // Consumes 5 food per unit time
        provides = ResourceType.Money,
        placementRule = PlacementRule.Anywhere,
        name = "House",
        prefab = Resources.Load<GameObject>("Prefabs/HousePrefab")
    };
}