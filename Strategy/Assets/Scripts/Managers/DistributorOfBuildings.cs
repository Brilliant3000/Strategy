using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class DistributorOfBuildings : MonoBehaviour
{
    public int maxBuildings;
    public int BuildingsCount { get; private set; }

    [SerializeField] private BuildingProgressBar progressBar;

    private List<Builder> listBuilders = new List<Builder>();
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
            listBuilders.Add(gameObject.AddComponent<Builder>());
            listBuilders.ElementAt(listBuilders.Count - 1).OnFinishedBuild += RemoveBuilder;
            listBuilders[listBuilders.Count - 1].StartBuild(ground, progressBarList.ElementAt(BuildingsCount));
            BuildingsCount++;
        }
    }

    private void RemoveBuilder(Builder builder)
    {
        listBuilders.Remove(builder);
        BuildingsCount--;
    }
}
