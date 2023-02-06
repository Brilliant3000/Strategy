using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private BuildManager buildManager;
    private SelectManager selectManager;

    private void Start()
    {
        buildManager = GetComponent<BuildManager>();
        selectManager = GetComponent<SelectManager>();
        buildManager.BuildFinished += OnSelectManager;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && selectManager.isActiveAndEnabled)
            selectManager.TrySelectGround();
    }
    public void SelectBuilding(BuildingConfig buildingConfig)
    {
        OffSelectManager();
        buildManager.PreparationToBuild(buildingConfig);
    }

    public void OnSelectManager()
    {
        StartCoroutine(Delay());
    }
    public void OffSelectManager()
    {
        selectManager.enabled = false;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        selectManager.enabled = true;
    }
}
