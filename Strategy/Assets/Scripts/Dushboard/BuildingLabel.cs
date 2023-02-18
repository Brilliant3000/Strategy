using UnityEngine;
using TMPro;

public class BuildingLabel : SignBaseUI
{
    [SerializeField] private TextMeshPro _name;
    [SerializeField] private TextMeshPro _level;
    public float size;

    private void Start()
    {
        FindOptimalSize(size);
        FindOptimalAngle();
    }

    public void SetValues(Building building)
    {
        _name.text = building.config.buildingName;
        _level.text = $"Level: {building.level}";

        transform.position = new Vector3(building.transform.position.x,
            building.transform.position.y + 1f, building.transform.position.z + 0.5f);
        FindOptimalSize(size);
        FindOptimalAngle();
    }
}
