using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DistributorOfDestroyers : MonoBehaviour
{
    public int maxBuildings;
    public int DestroyerCount { get; private set; }

    [SerializeField] private BuildingProgressBar progressBar;

    private List<Destroyer> listBuilders = new List<Destroyer>();
    private List<BuildingProgressBar> progressBarList = new List<BuildingProgressBar>();

    private void Start()
    {
        for (int i = 0; i < maxBuildings; i++)
            progressBarList.Add(Instantiate(progressBar));
    }

    public void Distribute(GroundElement ground)
    {
        if (DestroyerCount < maxBuildings)
        {
            listBuilders.Add(gameObject.AddComponent<Destroyer>());
            listBuilders.ElementAt(listBuilders.Count - 1).OnDestroyFinished += RemoveDestroyer;
            listBuilders[listBuilders.Count - 1].StartDestroy(ground, progressBarList.ElementAt(DestroyerCount));
            DestroyerCount++;
        }
    }

    private void RemoveDestroyer(Destroyer builder)
    {
        listBuilders.Remove(builder);
        DestroyerCount--;
    }
}
