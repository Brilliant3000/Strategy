using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundElement : MonoBehaviour
{
    public Building buildingHolder;
    [SerializeField] private bool accessBuild;
    private bool busy = false;
    public bool Busy
    {
        get
        {
            return busy;
        }
        set
        {
            if (accessBuild)
                busy = value;
        }
    }

    private void Start()
    {
        if (buildingHolder != null)
        {
            busy = true;
        }
        else
        {
            if (accessBuild) busy = false;
            else busy = true;
        }
    }

}
