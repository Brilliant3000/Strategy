using UnityEngine;
using UnityEngine.UI;

public class BuildDushBoard : SignBaseUI
{
    [SerializeField] private BuildManager _buildManager;
    [SerializeField] private Button _rotateLeft;
    [SerializeField] private Button _rotateRight;
    [SerializeField] private Button _apply;
    [SerializeField] private Button _cancel;
    [SerializeField] private float _size;
    private Building _building;

    private void Start()
    {
        _rotateLeft.onClick.AddListener(_buildManager.RotateLeft);
        _apply.onClick.AddListener(_buildManager.TryPlacing);
        _cancel.onClick.AddListener(_buildManager.CancelBuild);
        _rotateRight.onClick.AddListener(_buildManager.RotateRight);
        FindOptimalSize(_size);
        FindOptimalAngle();
    }
    public void Active(Building building)
    {
        _building = building;
        FindOptimalAngle();
        gameObject.SetActive(true);
    }

    public void Unactive()
    {
        _building = null;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_building != null)
        {
            FindOptimalSize(_size);
            transform.position = new Vector3(_building.transform.position.x,
                _building.transform.position.y + 0.5f, _building.transform.position.z + 0.5f);
        }
    }

}
