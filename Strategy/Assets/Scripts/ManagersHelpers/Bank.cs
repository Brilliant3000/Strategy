using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TerrainUtils;

public class Bank : MonoBehaviour
{
    public float returnInterest = 60;

	[SerializeField] private TextMeshProUGUI coinCounter;
    [SerializeField] private TextMeshProUGUI foodCounter;
    [SerializeField] private TextMeshProUGUI woodCounter;
	[SerializeField] private TextMeshProUGUI stoneCounter;

    [SerializeField] private int coin;
    [SerializeField] private int maxCoin = 100;

    [SerializeField] private int food;
    [SerializeField] private int maxFood = 100;

    [SerializeField] private int wood;
    [SerializeField] private int maxWood = 100;  

    [SerializeField] private int stone;
    [SerializeField] private int maxStone = 100;  

    private void Start()
    {
        coinCounter.text = $"{coin} / {maxCoin}";
        foodCounter.text = $"{food} / {maxFood}";
        woodCounter.text = $"{wood} / {maxWood}";
        stoneCounter.text = $"{stone} / {maxStone}";
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
			coinCounter.text = $"{coin} / {maxCoin}";
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
			foodCounter.text = $"{food} / {maxFood}";
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
			woodCounter.text = $"{wood} / {maxWood}";
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
			stoneCounter.text = $"{stone} / {maxStone}";
		}
	}

    public void CheckCost(Building building)
    {

    }

	public void SubtractCost(Building building)
	{

	}

    public void ReturnResources(Building building)
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
