using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    private List<Building> _buildingList;

    void Start()
    {
        _buildingList = Resources.LoadAll<Building>("f").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
