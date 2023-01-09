using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Assets/Scripts/ScriptableBuilding")]
public class BuildingInfo : ScriptableObject
{
     public string _name => _name;
     public Sprite _icon => _icon;

     public int _costInCoins => _costInCoins;
     public int _costInWood => _costInWood;
     public int _costInStone => _costInStone;
        
     public float _constructionTime => _constructionTime;
     public float _destroyTime => _destroyTime;
}
