using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingLabel : MonoBehaviour
{
    [SerializeField] private TextMeshPro _name;
    [SerializeField] private TextMeshPro _level;
    private Vector3 _cameraPosition;
    public float size;
    private void Start()
    {
        _cameraPosition = Camera.main.transform.position;
        FindOptimalSize();
    }

    public void SetValues(Building building)
    {
        _name.text = building.config.buildingName;
        _level.text = $"Level: {building.level}";

        transform.position = new Vector3(building.transform.position.x,
            building.transform.position.y + 1f, building.transform.position.z + 0.5f);
        FindOptimalSize();
    }

    private void FindOptimalSize()
    {
        float distance = Vector3.Distance(_cameraPosition, gameObject.transform.position);
        transform.localScale = Vector3.one * distance * size;
    }
}
