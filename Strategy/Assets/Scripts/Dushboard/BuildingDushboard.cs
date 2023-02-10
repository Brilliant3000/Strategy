using UnityEngine;
using UnityEngine.UI;

public class BuildingDushboard : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _destroyButton;
    [SerializeField] private Button _getInfoButton;

    [SerializeField] private DistributorOfDestroyers _distributor;
    [SerializeField] private UIHub _uiHub;

    [SerializeField] private BuildingLabel _buildingLabel;
    private GroundElement _ground;
    private Building _building;

    private void Start()
    {
        _getInfoButton.onClick.AddListener(Info);
        _destroyButton.onClick.AddListener(Destroy);
        _upgradeButton.onClick.AddListener(Upgrade);
        _buildingLabel = Instantiate(_buildingLabel.gameObject).GetComponent<BuildingLabel>();
    }

    public void Active(GroundElement ground)
    {
        _ground = ground;
        _building = ground.buildingHolder;
        Setup();
        _buildingLabel.SetValues(_ground.buildingHolder);
        _buildingLabel.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
    private void Setup()
    {
        _getInfoButton.gameObject.SetActive(true);

        if (_building.config.abilityDestroy == true)
        {
            _destroyButton.gameObject.SetActive(true);
        }
        else
        {
            _destroyButton.gameObject.SetActive(false);
        }  
        if (_building.config.buildingLevels.Length > 1)
        {
            _upgradeButton.gameObject.SetActive(true);
        }
        else
        {
            _upgradeButton.gameObject.SetActive(false);
        }
    }

    private void Info()
    {
        _uiHub.ActiveBuildingInfoPanel(_building);
        Deactivate();
    }  
    private void Destroy()
    {
        _distributor.Distribute(_ground);
        Deactivate();
    }
    private void Upgrade()
    {
        _uiHub.ActiveBuildingInfoPanelForUpdate(_building);
        Deactivate();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        _buildingLabel.gameObject.SetActive(false);
        _getInfoButton.gameObject.SetActive(false);
        _destroyButton.gameObject.SetActive(false);
        _upgradeButton.gameObject.SetActive(false);
    }
}
