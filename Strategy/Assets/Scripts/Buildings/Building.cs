using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingConfig config;

    public int health;
    public int resourceCount;
    public int level = 1;
    [HideInInspector] public TypeBuildings type;
    [HideInInspector] public GroundElement ground;

    public MeshRenderer Mesh { get; private set; }
    [HideInInspector] public Color[] colors;

    private void Awake()
    {
        Mesh = GetComponentInChildren<MeshRenderer>();
        colors = new Color[Mesh.materials.Length];

        for (int i = 0; i < Mesh.materials.Length; i++)
            colors[i] = Mesh.materials[i].color;
    }

    private void OnDestroy()
    {
        BuildingsCounter.instance.listBuildings.Remove(this);
    }
}
