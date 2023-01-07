using UnityEngine;

public class InputManager : MonoBehaviour
{
    private BuildManager buildManager;
    private SelectManager selectManager;

    private void Start()
    {
        buildManager = GetComponent<BuildManager>();
        selectManager = GetComponent<SelectManager>();
        buildManager.BuildFinished += SetSelect;
    }

    public void SetBuilding(Building building)
    {
        selectManager.enabled = false;
        buildManager.StartBuilding(building);
    }

    private void SetSelect()
    {
        selectManager.enabled = true;
    }
}
