using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour
{
    [SerializeField] public BuildingProgressBar buildingProgressBar;

    public GameObject unfinishedBuilding;
    private Building building; 
    private Bank bank;
    private int buildTime;
    private Vector3 buildPos;

    private void Start()
    {
        bank = GetComponent<Bank>();
    }

    public void StartBuilding(Building building, GroundElement ground)
    {
        this.building = building;

        buildTime = building.timeBuilding;
        buildingProgressBar.Active(building, buildTime);
        StartCoroutine(ColldownBuild());
   
        buildPos = new Vector3(ground.transform.position.x,
                    ground.transform.position.y + 0.5f, ground.transform.position.z);

        unfinishedBuilding.transform.position = buildPos;
        ground.Busy = true;
    }

    private void Build()
    {
        building.transform.position = buildPos; 
        building.gameObject.SetActive(true);
    }

    private void CalculationReurses()
    {
        bank.SubtractCost(building);
    }

    IEnumerator ColldownBuild()
    {
        yield return new WaitForSeconds(buildTime);
        Build();
        CalculationReurses();
    }
}
