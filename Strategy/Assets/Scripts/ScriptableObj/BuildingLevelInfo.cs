using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Assets/Scripts/ScriptableBuildingInfo")]
public class BuildingLevelInfo : ScriptableObject
{
    //If building desn't need some parameter than to assign -1 in inspector.

    [SerializeField] private Sprite _icon;
    [SerializeField] private int _level;

    [SerializeField] private int _health;
    [SerializeField] private int _capacity;
    [SerializeField] private int _productionRate;

    [Header("Defense")]
    [SerializeField] private int _damage;
    [SerializeField] private int _damagePerSecond;
    [SerializeField] private int _fireRate;
    [SerializeField] private int _fireDistance;
    [SerializeField] private int _damageType;

    [Header("BuildSettings")]
    [SerializeField] private int _costInCoins;
    [SerializeField] private int _costInWood;
    [SerializeField] private int _costInStone;

    [SerializeField] private float _constructionTime;
    [SerializeField] private float _destroyTime;

    [SerializeField] private GameObject _prefab;

    public Sprite icon => _icon;
    public int level => _level;

    public int health => _health;
    public int capacity => _capacity;
    public int productionRate => _productionRate;

    //Defense
    public int damage => _damage;
    public int damagePerSecond => _damagePerSecond;
    public int fireRate => _fireRate;
    public int fireDistance => _fireDistance;
    public int damageType => _damageType;

    //BuildSettrings
    public int costInCoins => _costInCoins;
    public int costInWood => _costInWood;
    public int costInStone => _costInStone;

    public float constructionTime => _constructionTime;
    public float destroyTime => _destroyTime;
    public GameObject prefab => _prefab;
}
