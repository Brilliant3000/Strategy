using System;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIBuildingInfo : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _updateButton;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _icon;

    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _capacityText;
    [SerializeField] private TextMeshProUGUI _productionRateText;

    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _capacitySlider;
    [SerializeField] private Slider _productionRateSlider;    

    [SerializeField] private Slider _healthUpgradeSlider;
    [SerializeField] private Slider _capacityUpgradeSlider;
    [SerializeField] private Slider _productionRateUpgradeSlider;

    [SerializeField] private TextMeshProUGUI _descrition;
    [SerializeField] private GameObject _blockUpgradePanel;

    private Building _building;
    private BuildingConfig _buildingConfig;
    private BuildingLevelInfo _buildingLevelInfo;
    private BuildingLevelInfo _nextBuildingLevelInfo;
    private BuildingLevelInfo _maxLevelBuildingInfo;
    private DistributorOfUpgraders _distributorOfUpgraders;
    private UIHub uiHub;

    private void Start()
    {
        _closeButton.onClick.AddListener(Deactive);
        uiHub = FindObjectOfType<UIHub>();
        _distributorOfUpgraders = FindObjectOfType<DistributorOfUpgraders>();
        _updateButton.onClick.AddListener(Deactive);
        _updateButton.onClick.AddListener(() => _distributorOfUpgraders.Distribute(_building.ground));
    }

    public void ShowInfo(Building building)
    {
        _building = building;
        _buildingConfig = building.config;
        _buildingLevelInfo = _buildingConfig.buildingLevels[building.level - 1];
        _maxLevelBuildingInfo = _buildingConfig.buildingLevels[_buildingConfig.buildingLevels.Length - 1];

        Setup();
        ActiveResourcesBarForInfo();

        _name.text = $"{_buildingConfig.buildingName} (lvl {_buildingLevelInfo.level})";
        _descrition.gameObject.SetActive(true);

        Active();
    }
    private void Setup()
    {
        _icon.sprite = _buildingLevelInfo.icon;
        _descrition.text = _buildingConfig.description;
    }
    public void ShowInfoForUpdate(Building building)
    {
        CheckOnExceptions(building);
        Setup();
        ActiveResourcesBarForUpdate();

        _name.text = $"{_buildingConfig.buildingName} (lvl {_buildingLevelInfo.level + 1})";
        _updateButton.gameObject.SetActive(true);
        if (Bank.instance.CheckCost(building.config.buildingLevels[building.level]))
        {
            _updateButton.interactable = true;
        }
        else
        {
            _updateButton.interactable = false;
        }
        Active();
    }

    
    private void ShowHealthBar()
    {
        _healthText.text = $"Health: {_building.health} / {_buildingLevelInfo.health}";
        _healthSlider.maxValue = _buildingLevelInfo.health;
        _healthSlider.value = _building.health;
        _healthSlider.gameObject.SetActive(true);
    }
    private void ShowCapacityBar()
    {
        _capacityText.text = $"Capacity: {_building.capacity} / {_buildingLevelInfo.capacity}";
        _capacitySlider.maxValue = _buildingLevelInfo.capacity;
        _capacitySlider.value = _building.capacity;
        _capacitySlider.gameObject.SetActive(true);
    }

    private void ShowProductionRateBar()
    {
        _productionRateText.text = $"ProductionRate: {_buildingLevelInfo.productionRate} / {_maxLevelBuildingInfo.productionRate}";
        _productionRateSlider.maxValue = _maxLevelBuildingInfo.productionRate;
        _productionRateSlider.value = _buildingLevelInfo.productionRate;
        _productionRateSlider.gameObject.SetActive(true);
    }

    private void ShowHealthBarForUpdate()
    {
        _healthText.text = $"Health: {_buildingLevelInfo.health} + {_nextBuildingLevelInfo.health - _buildingLevelInfo.health}";

        _healthUpgradeSlider.maxValue = _maxLevelBuildingInfo.health;
        _healthUpgradeSlider.value = _buildingLevelInfo.health + (_nextBuildingLevelInfo.health - _buildingLevelInfo.health);
        _healthSlider.maxValue = _maxLevelBuildingInfo.health;

        _healthSlider.value = _buildingLevelInfo.health;
        _healthUpgradeSlider.gameObject.SetActive(true);
        _healthSlider.gameObject.SetActive(true);
    }
    private void ShowCapacityBarForUpdate()
    {
        _capacityText.text = $"Capacity: {_buildingLevelInfo.capacity} + {_nextBuildingLevelInfo.capacity - _buildingLevelInfo.capacity}";

        _capacityUpgradeSlider.maxValue = _maxLevelBuildingInfo.capacity;
        _capacityUpgradeSlider.value = _buildingLevelInfo.capacity + (_nextBuildingLevelInfo.capacity - _buildingLevelInfo.capacity);
        _capacityUpgradeSlider.maxValue = _maxLevelBuildingInfo.capacity;

        _capacitySlider.maxValue = _maxLevelBuildingInfo.capacity;
        _capacitySlider.value = _buildingLevelInfo.capacity;
        _capacityUpgradeSlider.gameObject.SetActive(true);
        _capacitySlider.gameObject.SetActive(true);
    }
    private void ShowProductionRateBarForUpdate()
    {
        _productionRateText.text = $"ProductionRate: {_buildingLevelInfo.productionRate} + {_nextBuildingLevelInfo.productionRate - _buildingLevelInfo.productionRate}";

        _productionRateUpgradeSlider.maxValue = _maxLevelBuildingInfo.productionRate;
        _productionRateUpgradeSlider.value = _buildingLevelInfo.productionRate + (_nextBuildingLevelInfo.productionRate - _buildingLevelInfo.productionRate);
        _productionRateUpgradeSlider.maxValue = _maxLevelBuildingInfo.productionRate;

        _productionRateSlider.maxValue = _maxLevelBuildingInfo.productionRate;
        _productionRateSlider.value = _buildingLevelInfo.productionRate;
        _productionRateUpgradeSlider.gameObject.SetActive(true);
        _productionRateSlider.gameObject.SetActive(true);
    }

    private void ActiveResourcesBarForInfo()
    {
        if (_buildingLevelInfo.health > -1)
            ShowHealthBar();

        if (_buildingLevelInfo.capacity > -1)
            ShowCapacityBar();

        if (_buildingLevelInfo.productionRate > -1)
            ShowProductionRateBar();
    }
    private void ActiveResourcesBarForUpdate()
    {
        if (_buildingLevelInfo.health > -1)
            ShowHealthBarForUpdate();

        if (_buildingLevelInfo.capacity > -1)
            ShowCapacityBarForUpdate();

        if (_buildingLevelInfo.productionRate > -1)
            ShowProductionRateBarForUpdate();

    }
    private void CheckOnExceptions(Building building)
    {
        try
        {
            _building = building;
            _buildingConfig = building.config;
            _buildingLevelInfo = _buildingConfig.buildingLevels[building.level - 1];
            _nextBuildingLevelInfo = _buildingConfig.buildingLevels[building.level];
            _maxLevelBuildingInfo = _buildingConfig.buildingLevels[_buildingConfig.buildingLevels.Length - 1];
            _updateButton.interactable = true;
        }
        catch
        {
            ShowInfo(building);
            _descrition.gameObject.SetActive(false);
            _updateButton.gameObject.SetActive(true);
            _updateButton.interactable = false;
            _blockUpgradePanel.SetActive(true);
        }
    }

    private void Active()
    {
        gameObject.SetActive(true);
    }
    private void Deactive()
    {
        gameObject.SetActive(false);
        _healthSlider.gameObject.SetActive(false);
        _capacitySlider.gameObject.SetActive(false);
        _productionRateSlider.gameObject.SetActive(false);
        _updateButton.gameObject.SetActive(false);
        _descrition.gameObject.SetActive(false);
        _blockUpgradePanel.SetActive(false);

        _healthUpgradeSlider.gameObject.SetActive(false);
        _capacityUpgradeSlider.gameObject.SetActive(false);
        _productionRateUpgradeSlider.gameObject.SetActive(false);
        uiHub.OffSomePanel.Invoke();
    }
}
