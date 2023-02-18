using UnityEngine;

public class BuildingConstructor : MonoBehaviour
{
    private Building _prefab;
    private BuildingConfig _config;
    private int _level;
    public Building GetBuilding(BuildingConfig config, int level)
    {
        _level = level;
        _prefab = Instantiate(config.buildingLevels[level].prefab).GetComponent<Building>();
        _config = config;
        FillFields();
        BuildingsCounter.instance.listBuildings.Add(_prefab);
        Debug.Log(_prefab.config.buildingName);
        return _prefab;
    }

    private void FillFields()
    {
        _prefab.health = _config.buildingLevels[_level].health;
        _prefab.resourceCount = 0;
        _prefab.level = _config.buildingLevels[_level].level;
        _prefab.type = _config.type;
    }
}
