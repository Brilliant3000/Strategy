using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDushboard : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button destroyButton;
    [SerializeField] private Button getInfoButton;

    [SerializeField] private DistributorOfDestroyers queue;
    [SerializeField] private UIHub uiHub;

    private GroundElement ground;
    private Building building;

    private void Start()
    {
        getInfoButton.onClick.AddListener(Info);
        destroyButton.onClick.AddListener(Destroy);
        upgradeButton.onClick.AddListener(Upgrade);
    }

    public void Active(GroundElement ground)
    {
        gameObject.SetActive(true);
        this.ground = ground;
        building = ground.buildingHolder;
    }

    private void Info()
    {
        uiHub.ActiveBuildingInfoPanel(building);
        gameObject.SetActive(false);
    }  
    private void Destroy()
    {
        queue.Distribute(ground);
        gameObject.SetActive(false);
    }
    private void Upgrade()
    {
        uiHub.ActiveBuildingInfoPanelForUpdate(building);
        gameObject.SetActive(false);
    }
}
