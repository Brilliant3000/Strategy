using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
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
        return _prefab;
    }

    private void FillFields()
    {
        _prefab.health = _config.buildingLevels[_level].health;
        _prefab.capacity = 0;
        _prefab.level = _config.buildingLevels[_level].level;
        _prefab.type = _config.type;
    }
}
