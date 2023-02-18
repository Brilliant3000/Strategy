using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private BuildManager _buildManager;
    private SelectManager _selectManager;
    private CameraController _cameraConroller;

    private void Start()
    {
        _buildManager = GetComponent<BuildManager>();
        _selectManager = GetComponent<SelectManager>();
        _cameraConroller = FindObjectOfType<CameraController>();
        _buildManager.BuildFinished += OnSelectManager;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _selectManager.isActiveAndEnabled)
            _selectManager.TrySelectGround();
    }

    public void SelectBuilding(BuildingConfig buildingConfig)
    {
        OffSelectManager();
        _buildManager.PreparationToBuild(buildingConfig);
    }

    public void OnSelectManager()
    {
        StartCoroutine(Delay());
        _cameraConroller.enabled = true;
    }

    public void OffSelectManager()
    {
        _selectManager.enabled = false;
        _selectManager.Deselect();
        _cameraConroller.enabled = false;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        _selectManager.enabled = true;
    }
}
