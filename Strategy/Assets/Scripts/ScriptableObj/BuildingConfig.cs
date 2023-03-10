using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Assets/Scripts/ScriptableBuildingConfig")]
public class BuildingConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _level = 1;
    [SerializeField] private int _id;
    [SerializeField] private TypeBuildings _type;
    [SerializeField] private string _description;
    [SerializeField] private bool _abilityDestroy = true;
    [SerializeField] private bool _hideInShop;

    [SerializeField] private BuildingLevelInfo[] _buildingsLevel;

    public string buildingName => _name;
    public TypeBuildings type => _type;
    public int level => _level;
    public int id => _id;
    public string description => _description;
    public bool abilityDestroy => _abilityDestroy;
    public bool hideInShop => _hideInShop;
    public BuildingLevelInfo[] buildingLevels => _buildingsLevel;
}
