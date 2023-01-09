
using UnityEngine;
using System;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    private int timeDestroy;
    private Bank bank;
    private Building building;
    public Action OnDestroy;
    public BuildingProgressBar buildingProgressBar;

    private void Start()
    {
        bank = GetComponent<Bank>();
    }

    public void StartDestroy(GroundElement ground)
    {
        building = ground.buildingHolder;
        timeDestroy = building.timeDestroy;
        buildingProgressBar.Active(building, timeDestroy);
        StartCoroutine(ColldownDestroy());
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
        bank.ReturnResources(building);
    }

    IEnumerator ColldownDestroy()
    {
        yield return new WaitForSeconds(timeDestroy);
        DestroyBuilding();
        ReturnResurses();
    }
}
