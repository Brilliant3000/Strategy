using UnityEngine;
using UnityEngine.UI;

public class BuildDushBoard : MonoBehaviour
{
    [SerializeField] private BuildManager buildManager;
    [SerializeField] private Button rotateLeft;
    [SerializeField] private Button rotateRight;
    [SerializeField] private Button apply;
    private Building building;

    public void SetBuild(Building building)
    {
        gameObject.SetActive(true);
        this.building = building;
        rotateLeft.onClick.AddListener(building.RotateLeft);  
        
        rotateRight.onClick.AddListener(building.RotateRight);

        apply.onClick.AddListener(buildManager.TryPlacing);
    }

    public void RemoveBuild()
    {
        rotateLeft.onClick.RemoveAllListeners();

        rotateRight.onClick.RemoveAllListeners();

        apply.onClick.RemoveAllListeners();
        building = null;
        gameObject.SetActive(false);

    }

    private void Update()
    {
        if(building != null)
        {
            transform.position = new Vector3(building.transform.position.x, 
                building.transform.position.y + 0.15f, building.transform.position.z);
        }
    }

}
