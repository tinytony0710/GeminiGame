using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public int wood;
    public int stone;
    public int food;
    public int money;

    public int incomePerTurn;

    // ... (other variables)

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

    public void GatherResources(ResourceType resourceType, int amount)
    {
        switch(resourceType)
        {
            case ResourceType.Wood:
                wood += amount;
                break;
            case ResourceType.Stone:
                stone += amount;
                break;
            case ResourceType.Food:
                food += amount;
                break;
            case ResourceType.Money:
                money += amount;
                break;
        }
    }

    public bool ConsumeResources(ResourceType resourceType, int amount)
    {
        switch(resourceType)
        {
            case ResourceType.Wood:
                if(wood >= amount)
                {
                    wood -= amount;
                    return true;
                }
                break;
            case ResourceType.Stone:
                if(stone >= amount)
                {
                    stone -= amount;
                    return true;
                }
                break;
            case ResourceType.Food:
                if(food >= amount)
                {
                    food -= amount;
                    return true;
                }
                break;
            case ResourceType.Money:
                if(money >= amount)
                {
                    money -= amount;
                    return true;
                }
                break;
        }

        return false;
    }

    public bool CheckResourceAvailability(ResourceType resourceType, int amount)
    {
        switch(resourceType)
        {
            case ResourceType.Wood:
                return wood >= amount;
            case ResourceType.Stone:
                return stone >= amount;
            case ResourceType.Food:
                return food >= amount;
            case ResourceType.Money:
                return money >= amount;
            default:
                return false;
        }
    }

    public void GenerateIncome()
    {
        money += incomePerTurn;
    }
}