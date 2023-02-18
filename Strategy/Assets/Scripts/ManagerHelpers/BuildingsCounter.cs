using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsCounter : MonoBehaviour
{
    public static BuildingsCounter instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public List<Building> listBuildings = new List<Building>();
}
