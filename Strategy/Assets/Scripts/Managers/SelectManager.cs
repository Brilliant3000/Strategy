using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private SelectDushboard selectDushboard;
    [SerializeField] private BuildingDushboard buildingDushboard;

    private Camera mainCamera;
    private GroundElement ground;
    private Building building;


    void Start()
    {
        mainCamera = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    selectDushboard.SetPosition(hit.collider.GetComponent<GroundElement>());
                    ground = hit.collider.GetComponent<GroundElement>();

                    if (ground.buildingHolder != null)
                        GetBuilding();
                }
            }
        }
    }

    private void GetBuilding()
    {
        building = ground.buildingHolder; 
        buildingDushboard.SetBuilding(ground);
    }

    private void GetGround()
    {

    }
}
