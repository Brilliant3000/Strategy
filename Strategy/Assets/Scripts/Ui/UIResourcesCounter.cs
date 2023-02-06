using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIResourcesCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounter;
    [SerializeField] private TextMeshProUGUI foodCounter;
    [SerializeField] private TextMeshProUGUI woodCounter;
    [SerializeField] private TextMeshProUGUI stoneCounter;
    [SerializeField] private TextMeshProUGUI gemCounter;

    [SerializeField] private Slider coinBar;
    [SerializeField] private Slider foodBar;
    [SerializeField] private Slider woodBar;
    [SerializeField] private Slider stoneBar;

    private void Start()
    {
        UpdateCoinBar();
        UpdateFoodBar();
        UpdateWoodBar();
        UpdateStoneBar();
    }

    public void UpdateCoinBar()
    {
        coinCounter.text = Bank.instance.Coin.ToString();
        coinBar.maxValue = Bank.instance.maxCoin;
        coinBar.value = Bank.instance.Coin;
    }
    public void UpdateFoodBar()
    {
        foodCounter.text = Bank.instance.Food.ToString();
        foodBar.maxValue = Bank.instance.maxFood;
        foodBar.value = Bank.instance.Food;
    }  
    public void UpdateWoodBar()
    {
        woodCounter.text = Bank.instance.Wood.ToString();
        woodBar.maxValue = Bank.instance.maxWood;
        woodBar.value = Bank.instance.Wood;
    }    
    public void UpdateStoneBar()
    {
        stoneCounter.text = Bank.instance.Stone.ToString();
        stoneBar.maxValue = Bank.instance.maxStone;
        stoneBar.value = Bank.instance.Stone;
    }
}
