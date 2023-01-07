using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Assets/Scripts/ScriptableBuilding")]
public class BuildingInfo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    [SerializeField] private int _costInCoins;
    [SerializeField] private int _costInWood;
    [SerializeField] private int _costInStone;

    [SerializeField] private float _constructionTime;
}
