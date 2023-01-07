using UnityEngine;

public class Builder : MonoBehaviour
{
    private Building building; 
    private GroundElement ground;
    private Bank bank;


    private void Start()
    {
        bank = GetComponent<Bank>();
    }
    public void StartBuilding(Building building, GroundElement ground)
    {
        this.building = building;
        this.ground = ground;
        CalculationReurses();
        Build();
    }

    private void Build()
    {
        building.transform.position = new Vector3(ground.transform.position.x,
                    ground.transform.position.y + 0.5f, ground.transform.position.z); 
    }

    private void CalculationReurses()
    {
        bank.Coin -= building.cost;
    }
}
