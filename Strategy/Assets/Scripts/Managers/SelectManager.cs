using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private SelectDushboard selectDushboard; //?
    [SerializeField] private BuildingDushboard buildingDushboard; //?

    private Camera mainCamera;
    private GroundElement ground;
    private Collider tempGround;

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void TrySelectGround()
    {
        RaycastHit hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != tempGround || tempGround == null)
            {
                ground = hit.collider.GetComponent<GroundElement>();
                selectDushboard.SetPosition(ground); //?

                if (ground.buildingHolder != null)
                {
                    GetBuilding();
                }
                else
                {
                    selectDushboard.RemovePosition(); //?
                    buildingDushboard.gameObject.SetActive(false); //?
                }
                tempGround = hit.collider;
            }
            else
            {
                buildingDushboard.gameObject.SetActive(false); //?
                selectDushboard.RemovePosition(); //?
                tempGround = null;
            }
        }
    }

    private void GetBuilding()
    {
        buildingDushboard.Active(ground);
    }
}
