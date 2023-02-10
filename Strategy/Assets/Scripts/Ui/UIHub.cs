using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class UIHub : MonoBehaviour
{
    public Action OnSomePanel;
    public Action OffSomePanel;
    public Action OnPanelWithoutSelectManager;
    public Action OffPanelWithoutSelectManager;

    private InputManager _inputManager;
    private CameraController _cameraController;

    [Tooltip("1233")]
    [SerializeField] private GameObject _backGroundPanel;

    [SerializeField] private UIBuildingInfo _buildingInfoPanel;
    [SerializeField] private BuildingShop _buildingShopPanel;
    private void Start()
    {
        OnSomePanel += OnSomeFunctions;
        OffSomePanel += OffSomeFunctions;
        OnPanelWithoutSelectManager += OnPanelWithoutInputManager;
        OffPanelWithoutSelectManager += OffPanelWithoutInputManager;
        _inputManager = GetComponent<InputManager>();
        _cameraController = FindObjectOfType<CameraController>();
    }
    public void ActiveBuildingInfoPanel(Building building)
    {
        _buildingInfoPanel.ShowInfo(building);
        OnSomePanel.Invoke();
    } 
    public void ActiveBuildingInfoPanelForUpdate(Building building)
    {
        _buildingInfoPanel.ShowInfoForUpdate(building);
        OnSomePanel.Invoke();
    }

    public void ActiveBuildingShop()
    {
        _buildingShopPanel.gameObject.SetActive(true);
        OnSomePanel.Invoke();
    }

    private void OnSomeFunctions()
    {
        _backGroundPanel.SetActive(true);
        _inputManager.OffSelectManager();
        _cameraController.enabled = false;
    }   

    private void OnPanelWithoutInputManager()
    {
        _backGroundPanel.SetActive(true);
        _cameraController.enabled = false;
    }
    private void OffPanelWithoutInputManager()
    {
        _backGroundPanel.SetActive(false);
        _cameraController.enabled = true;
    }

    private void OffSomeFunctions()
    {
        _backGroundPanel.SetActive(false);
        _inputManager.OnSelectManager();
        _cameraController.enabled = true;
    }    
}
