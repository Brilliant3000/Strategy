using UnityEngine;
using System;

public class Destroyer : MonoBehaviour
{
    private Bank bank;
    private Building building;
    public Action OnDestroy;

    private void Start()
    {
        bank = GetComponent<Bank>();
    }
    public void StartDestroy(GroundElement ground)
    {
       this.building = ground.buildingHolder;
        DestroyBuilding();
        ground.Busy = false;
    }

    public void DestroyBuilding()
    {
        if(building != null)
            Destroy(building.gameObject);
        OnDestroy?.Invoke();
        
    }

    private void ReturnResurses()
    {
        
    }
}
