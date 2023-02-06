using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class UIHub : MonoBehaviour
{
    public Action OnSomePanel;
    public Action OffSomePanel;
    private InputManager inputManager;
    private CameraController cameraController;

    [Tooltip("1233")]
    [SerializeField] private GameObject backGroundPanel;

    [SerializeField] private UIBuildingInfo buildingInfoPanel;
    private void Start()
    {
        OnSomePanel += OnSomeFunctions;
        OffSomePanel += OffSomeFunctions;
        inputManager = GetComponent<InputManager>();
        cameraController = FindObjectOfType<CameraController>();
    }
    public void ActiveBuildingInfoPanel(Building building)
    {
        buildingInfoPanel.ShowInfo(building);
        OnSomePanel.Invoke();
    } 
    public void ActiveBuildingInfoPanelForUpdate(Building building)
    {
        buildingInfoPanel.ShowInfoForUpdate(building);
        OnSomePanel.Invoke();
    }

    private void OnSomeFunctions()
    {
        backGroundPanel.SetActive(true);
        inputManager.OffSelectManager();
        cameraController.enabled = false;
    }   

    private void OffSomeFunctions()
    {
        backGroundPanel.SetActive(false);
        inputManager.OnSelectManager();
        cameraController.enabled = true;
    }    
}
