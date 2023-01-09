using UnityEngine;
using UnityEngine.UI;

public class BuildingDushboard : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button destroyButton;
    [SerializeField] private Button getInfoButton;
    [SerializeField] private Destroyer destroyer;
    private GroundElement ground;
    private Building building;

    private void Start()
    {
        destroyButton.onClick.AddListener(Destroy);
        destroyer.OnDestroy += DestroyEnd;
    }
    public void SetBuilding(GroundElement ground)
    {
        gameObject.SetActive(true);

        this.ground = ground;
        building = ground.buildingHolder;

        if(building != null )
            transform.position = new Vector3(building.transform.position.x, 
                building.transform.position.y + 0.8f, building.transform.position.z + 0.5f);
    }

    private void Destroy()
    {
        destroyer.StartDestroy(ground);
    }

    private void DestroyEnd()
    {
        gameObject.SetActive(false);
    }

}
