using System;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Action BuildFinished;
    [SerializeField] private BuildDushBoard buildingDushBoard;

    private Camera mainCamera;
    private Building flyingBuilding;
    private GroundElement ground;
    private Collider tempGround;
    private DistributorOfBuildings BuilderQueue;
    private PlaceVerificator verificator;
    private BuildingConstructor buildingConstructor;

    void Start()
    {
        mainCamera = Camera.main;
        BuilderQueue = GetComponent<DistributorOfBuildings>();
        verificator = new PlaceVerificator();
        buildingConstructor = gameObject.AddComponent<BuildingConstructor>();
    }

    public void PreparationToBuild(BuildingConfig buildingConfig)
    {
        if (flyingBuilding != null)
            Destroy(flyingBuilding.gameObject);

        flyingBuilding = buildingConstructor.GetBuilding(buildingConfig, 0);
        buildingDushBoard.SetBuild(flyingBuilding); //?
    }

    void Update()
    {
        if (flyingBuilding != null)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != tempGround || tempGround == null)
                {
                    ground = hit.collider.GetComponent<GroundElement>();

                    CheckPlaceFit();
                    flyingBuilding.transform.position = new Vector3(hit.transform.position.x,
                    hit.transform.position.y + 0.5f, hit.transform.position.z);

                    tempGround = hit.collider;
                }
            }
        }
    }

    private bool CheckPlaceFit()
    {
        bool acces = verificator.StartVeifi(ground, flyingBuilding);

        if (acces)
        {
            flyingBuilding.SetTransparent(false);
            return true;
        }
        else
        {
            flyingBuilding.SetTransparent(true);
            return false;
        }
    }

    public void TryPlacing()
    {
        if (BuilderQueue.BuildingsCount < BuilderQueue.maxBuildings)
        {
            if (flyingBuilding != null && CheckPlaceFit())
            {
                ground.buildingHolder = flyingBuilding;
                StartBuild(); //?
            }
            else if (flyingBuilding != null)
            {
                buildingDushBoard.RemoveBuild(); //?
                Destroy(flyingBuilding.gameObject);
            }
            BuildFinished?.Invoke();
        }
    }

    private void StartBuild() //?
    {
        BuilderQueue.Distribute(ground);
        flyingBuilding.SetDefault();
        buildingDushBoard.RemoveBuild(); //?

        flyingBuilding.gameObject.SetActive(false);
        flyingBuilding = null;
    }
}
