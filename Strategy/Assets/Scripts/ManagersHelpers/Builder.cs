using System;
using System.Collections;
using UnityEngine;

public class Builder : MonoBehaviour
{
    private BuildingProgressBar buildingProgressBar;
    private Building building;
    private Bank bank = Bank.instance;

    public Action<Builder> OnFinishedBuild;

    public void StartBuild(GroundElement ground, BuildingProgressBar progress)
    {
        building = ground.buildingHolder;
        buildingProgressBar = progress;
        ground.buildingHolder.ground = ground;

        buildingProgressBar.ActiveBuildMode(building, true);
        StartCoroutine(DelayBeforeBuild());
        ground.Busy = true;
    }

    private void Build()
    {
        building.gameObject.SetActive(true);
    }

    IEnumerator DelayBeforeBuild()
    {
        yield return new WaitForSeconds(building.config.buildingLevels[building.level - 1].constructionTime);
        Build();
        bank.SubtractCost(building.config.buildingLevels[building.level - 1]);
        OnFinishedBuild?.Invoke(this);
        Destroy(this);
    }
}
