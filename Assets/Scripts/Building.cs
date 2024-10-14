using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingData buildingData;
    public Vector3 gridPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateResources()
    {
        // Update resource production and consumption based on buildingData
        // For example:
        // ResourceManager.Instance.ProduceResources(buildingData.resourceProduction, buildingData.provides);
        // ResourceManager.Instance.ConsumeResources(buildingData.resourceConsumption, buildingData.resourceConsumptionType);
    }
}
