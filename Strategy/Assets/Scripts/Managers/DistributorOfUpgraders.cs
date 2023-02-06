using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DistributorOfUpgraders : MonoBehaviour
{
    public int maxBuildings;
    public int BuildingsCount { get; private set; }

    [SerializeField] private BuildingProgressBar progressBar;

    private List<Upgrader> listUpgraders = new List<Upgrader>();
    private List<BuildingProgressBar> progressBarList = new List<BuildingProgressBar>();

    private void Start()
    {
        for (int i = 0; i < maxBuildings; i++)
            progressBarList.Add(Instantiate(progressBar));
    }

    public void Distribute(GroundElement ground)
    {
        if (BuildingsCount < maxBuildings)
        {
            listUpgraders.Add(gameObject.AddComponent<Upgrader>());
            listUpgraders.ElementAt(listUpgraders.Count - 1).OnFinishedUpdate += RemoveBuilder;
            listUpgraders[listUpgraders.Count - 1].StartUpdate(ground, progressBarList.ElementAt(BuildingsCount));
            BuildingsCount++;
        }
    }

    private void RemoveBuilder(Upgrader upgrader)
    {
        listUpgraders.Remove(upgrader);
        BuildingsCount--;
    }
}
