using UnityEngine;
using System;
using Unity.VisualScripting;

public class BuildManager : MonoBehaviour
{
    public Action BuildFinished;

    [SerializeField] private LayerMask layerGround;
    [SerializeField] private BuildDushBoard buildingDushBoard;

    private Camera mainCamera;

    private Building flyingBuilding;
    private Collider hitCollider;
    private GroundElement groundElement;
    private Builder builder;
    private Bank bank;

    void Start()
    {
        mainCamera = Camera.main;    
        builder = GetComponent<Builder>();
        bank = GetComponent<Bank>();
    }

    public void StartBuilding(Building buildingPrefab)
    {
        if(flyingBuilding != null) 
            Destroy(flyingBuilding.gameObject);

        flyingBuilding = Instantiate(buildingPrefab);
        buildingDushBoard.SetBuild(flyingBuilding);
    }

    void Update()
    {
        if (flyingBuilding != null)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,layerGround))
            {
                hitCollider = hit.collider;
                groundElement = hit.collider.GetComponent<GroundElement>();

                CheckPlace();
                Vector3 pos = new Vector3(hit.transform.position.x,
                hitCollider.transform.position.y + 0.5f, hit.transform.position.z);

                flyingBuilding.transform.position = pos;
            }
        }
    }

    private void CheckPlace()
    {
        if(groundElement.Busy == true)
        {
            flyingBuilding.SetTransparent(true);
        }
        else
        {
            flyingBuilding.SetTransparent(false);
        }
    }

    public void TryPlacing()
    {
        if (groundElement.Busy == false && CheckCost())
        {
            groundElement.buildingHolder = flyingBuilding;
            Build();
 
        }
        else if (flyingBuilding != null)
        {
            BuildFinished.Invoke();
            buildingDushBoard.RemoveBuild();
            Destroy(flyingBuilding.gameObject);
        }
    }

    private bool CheckCost()
    {
        if(bank.Coin >= flyingBuilding.costInCoins)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Build()
    {
        builder.StartBuilding(flyingBuilding, groundElement);
        flyingBuilding.SetDefault();

        buildingDushBoard.RemoveBuild();
        flyingBuilding.gameObject.SetActive(false);

        flyingBuilding = null;
        BuildFinished?.Invoke();
    }
}
