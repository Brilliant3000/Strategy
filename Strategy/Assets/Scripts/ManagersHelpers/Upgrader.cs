using System;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    private BuildingProgressBar buildingProgressBar;
    private Building building;
    private Bank bank = Bank.instance;
    private BuildingConstructor buildingConstructor;
    private GroundElement _ground;
    public Action<Upgrader> OnFinishedUpdate;
    
    public void StartUpdate(GroundElement ground, BuildingProgressBar progress)
    {
        building = ground.buildingHolder;
        buildingProgressBar = progress;
        _ground = ground;

        buildingProgressBar.ActiveBuildMode(building, true);
        if(buildingConstructor == null) 
            buildingConstructor = GetComponent<BuildingConstructor>();

        StartCoroutine(DelayBeforeUpdate());
        ground.Busy = true;
    }

    private void UpdateBuilding()
    {
        Building oldBuilding = building;
        building = buildingConstructor.GetBuilding(oldBuilding.config, oldBuilding.level);
        building.transform.position = oldBuilding.transform.position;
        building.transform.rotation = oldBuilding.transform.rotation;
        building.ground = _ground;
        _ground.buildingHolder = building;
        Destroy(oldBuilding.gameObject);
    }

    IEnumerator DelayBeforeUpdate()
    {
        yield return new WaitForSeconds(building.config.buildingLevels[building.level-1].constructionTime);
        bank.SubtractCost(building.config.buildingLevels[building.level - 1]);
        UpdateBuilding();
        OnFinishedUpdate?.Invoke(this);
        Destroy(this);
    }
}
