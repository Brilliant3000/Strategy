
using System;
using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Building building;
    private GroundElement ground;
    public Action<Destroyer> OnDestroyFinished;
    private float timeDestroy;

    public void StartDestroy(GroundElement ground, BuildingProgressBar progressBar)
    {
        this.ground = ground;
        building = ground.buildingHolder;
        timeDestroy = building.config.buildingLevels[building.level - 1].destroyTime;
        progressBar.ActiveDestroyMode(building, false);
        StartCoroutine(DelayBeforeDestroy());
    }

    private void DestroyBuilding()
    {
        if (building != null)
            Destroy(building.gameObject);
        ground.Busy = false;
    }

    private void ReturnResursesInBank()
    {
        Bank.instance.ReturnResources(building.config.buildingLevels[building.level - 1]);
    }

    IEnumerator DelayBeforeDestroy()
    {
        yield return new WaitForSeconds(timeDestroy);
        DestroyBuilding();
        ReturnResursesInBank();
        OnDestroyFinished?.Invoke(this);
        Destroy(this);
    }
}
