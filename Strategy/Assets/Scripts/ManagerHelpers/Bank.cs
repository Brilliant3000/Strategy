using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank instance;

    public float returnInterest = 60;

    [SerializeField] private int coin;
    public int maxCoin { get; private set; } = 850;

    [SerializeField] private int food;
    public int maxFood { get; private set; } = 850;

    [SerializeField] private int wood;
    public int maxWood { get; private set; } = 850;

    [SerializeField] private int stone;
    public int maxStone { get; private set; } = 850;

    private UIResourcesCounter uIResourcesCounter;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        uIResourcesCounter = FindObjectOfType<UIResourcesCounter>();
    }

    public int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
            coin = Mathf.Clamp(coin, 0, maxCoin);
            uIResourcesCounter.UpdateCoinBar();
        }
    }
    public int Food
    {
        get
        {
            return food;
        }
        set
        {
            food = value;
            food = Mathf.Clamp(food, 0, maxFood);
            uIResourcesCounter.UpdateFoodBar();
        }
    }

    public int Wood
    {
        get
        {
            return wood;
        }
        set
        {
            wood = value;
            wood = Mathf.Clamp(wood, 0, maxWood);
            uIResourcesCounter.UpdateWoodBar();
        }
    }

    public int Stone
    {
        get
        {
            return stone;
        }
        set
        {
            stone = value;
            stone = Mathf.Clamp(stone, 0, maxStone);
            uIResourcesCounter.UpdateStoneBar();
        }
    }

    public bool CheckCost(BuildingLevelInfo building)
    {
        if (building.costInCoins > coin) return false;
        if (building.costInWood > wood) return false;
        if (building.costInStone > stone) return false;
        return true;
    }

    public void SubtractCost(BuildingLevelInfo building)
    {
        Coin -= building.costInCoins;
        Wood -= building.costInWood;
        Stone -= building.costInStone;
    }

    public void ReturnResources(BuildingLevelInfo building)
    {
        Coin += GetInterest(building.costInCoins);
        Wood += GetInterest(building.costInWood);
        Stone += GetInterest(building.costInStone);
    }

    private int GetInterest(float cost)
    {
        float oneInterest = cost / 100;
        int result = Mathf.RoundToInt(oneInterest * returnInterest);

        return result;
    }
}
