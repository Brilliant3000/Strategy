using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildManager : MonoBehaviour
{
    public Action BuildFinished;
    [SerializeField] private BuildDushBoard _buildDushBoard;
    [SerializeField] private Color _accesBuildColor;
    [SerializeField] private Color _unaccesBuildColor;
    public int rotateAngle;
    private float _angle = 0;

    private Camera _mainCamera;
    private Building _flyingBuilding;
    private GroundElement _ground;
    private Collider _tempGround;
    private DistributorOfBuildings _BuilderDistributor;
    private PlaceVerificator _verificator;
    private BuildingConstructor _buildingConstructor;
    private MeshRenderer _meshFyingBuilding;
    private bool _buildingPermit = true;

    void Start()
    {
        _mainCamera = Camera.main;
        _BuilderDistributor = GetComponent<DistributorOfBuildings>();
        _verificator = new PlaceVerificator();
        _buildingConstructor = gameObject.AddComponent<BuildingConstructor>();
    }

    public void PreparationToBuild(BuildingConfig buildingConfig)
    {
        if (_flyingBuilding != null)
            Destroy(_flyingBuilding.gameObject);

        _flyingBuilding = _buildingConstructor.GetBuilding(buildingConfig, 0);
        _buildDushBoard.Active(_flyingBuilding);
        _meshFyingBuilding = _flyingBuilding.Mesh;
    }

    void Update()
    {
        if (_flyingBuilding != null && _buildingPermit)
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != _tempGround || _tempGround == null)
                {
                    _ground = hit.collider.GetComponent<GroundElement>();

                    CheckPlaceFit();
                    _flyingBuilding.transform.position = new Vector3(hit.transform.position.x,
                    hit.transform.position.y + 0.5f, hit.transform.position.z);

                    _tempGround = hit.collider;
                }
            }
        }
    }

    private bool CheckPlaceFit()
    {
        bool acces = _verificator.StartVeifi(_ground, _flyingBuilding);

        if (acces)
        {
            SetTransparent(false);
            return true;
        }
        else
        {
            SetTransparent(true);
            return false;
        }
    }

    public void TryPlacing()
    {
        if (_BuilderDistributor.BuildingsCount < _BuilderDistributor.maxBuildings)
        {
            if (_flyingBuilding != null && CheckPlaceFit())
            {
                _buildingPermit = false;
                _ground.buildingHolder = _flyingBuilding;
                StartBuild();
            }
            else if (_flyingBuilding != null)
            {
                _buildDushBoard.Unactive();
                Destroy(_flyingBuilding.gameObject);
            }
            _buildingPermit = true;
            BuildFinished?.Invoke();
        }
    }

    private void StartBuild() 
    {
        _angle = 0;
        _BuilderDistributor.Distribute(_ground);
        SetDefaultTransparent();
        _buildDushBoard.Unactive(); 

        _flyingBuilding.gameObject.SetActive(false);
        _flyingBuilding = null;
    }

    private void SetTransparent(bool available)
    {
        if (available)
        {
            for (int i = 0; i < _meshFyingBuilding.materials.Length; i++)
                _meshFyingBuilding.materials[i].color = _unaccesBuildColor;
        }
        else
        {
            for (int i = 0; i < _meshFyingBuilding.materials.Length; i++)
                _meshFyingBuilding.materials[i].color = _accesBuildColor;
        }
    }

    public void SetDefaultTransparent()
    {
        for (int i = 0; i < _meshFyingBuilding.materials.Length; i++)
            _meshFyingBuilding.materials[i].color = _flyingBuilding.colors[i];
    }

    public void CancelBuild()
    {
        _buildingPermit = false;
        _buildDushBoard.Unactive();
        Destroy(_flyingBuilding.gameObject);
        _buildingPermit = true;
    }

    public void RotateRight()
    {
        _buildingPermit = false;
        _angle -= rotateAngle;
        _flyingBuilding.transform.localEulerAngles = new Vector3(0, _angle, 0);
        _buildingPermit = true;
    }
    public void RotateLeft()
    {
        _buildingPermit = false;
        _angle += rotateAngle;
        _flyingBuilding.transform.localEulerAngles = new Vector3(0, _angle, 0);
        _buildingPermit = true;
    }
}
