using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;

public class BuildingShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _constructionTime;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private TextMeshProUGUI _cost;

    [SerializeField] private Button _infoButton;
    public Button shopCardButton;
    
    [SerializeField] private Image _image;

    private InputManager _inputManager;
    private BuildingLevelInfo _buildingLevelInfo;
    [HideInInspector] public BuildingConfig buildingConfig;


    private void Start()
    {
        _inputManager = FindObjectOfType<InputManager>();
        shopCardButton = GetComponent<Button>();
    }
    public void SetValues(BuildingConfig config)
    {
        buildingConfig = config;
        _buildingLevelInfo = config.buildingLevels[0];
        FillFields();
        _infoButton.onClick.AddListener(GetInfo);
        shopCardButton.onClick.AddListener(Buy);
    }

    private void FillFields()
    {
        _name.text = buildingConfig.buildingName;
        _constructionTime.text = $"{_buildingLevelInfo.constructionTime}m";
        _count.text = $"{0} / {0}";
        _cost.text = $"{_buildingLevelInfo.costInCoins}$";
        _image.sprite = _buildingLevelInfo.icon;
    }

    private void GetInfo()
    {

    }

    private void Buy()
    {
        _inputManager.SelectBuilding(buildingConfig);
    }

}
