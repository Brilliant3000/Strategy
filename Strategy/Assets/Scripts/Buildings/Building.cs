using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingConfig config;

    public int health;
    [HideInInspector] public int capacity;
    public int level = 1;
    [HideInInspector] public TypeBuildings type;
    [HideInInspector] public GroundElement ground;

    [Header("Parameters")]
    public int rotateAngle;

    public MeshRenderer mesh;
    private Color[] colors;
    private float angle = 0;

    private void Start()
    {
        colors = new Color[mesh.materials.Length];

        for (int i = 0; i < mesh.materials.Length; i++)
            colors[i] = mesh.materials[i].color;
    }
    public void SetTransparent(bool available)
    {
        if (available)
        {
            for (int i = 0; i < mesh.materials.Length; i++)
                mesh.materials[i].color = new Color(1, 0, 0, 0.3f);
        }
        else
        {
            for (int i = 0; i < mesh.materials.Length; i++)
                mesh.materials[i].color = new Color(0, 1, 0, 0.3f);
        }
    }

    public void SetDefault()
    {
        for (int i = 0; i < mesh.materials.Length; i++)
            mesh.materials[i].color = colors[i];
    }

    public void RotateRight()
    {
        angle -= rotateAngle;
        transform.localEulerAngles = new Vector3(0, angle, 0);
    }
    public void RotateLeft()
    {
        angle += rotateAngle;
        transform.localEulerAngles = new Vector3(0, angle, 0);
    }
}
