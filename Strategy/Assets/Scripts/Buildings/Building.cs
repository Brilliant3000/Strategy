using UnityEngine;

public class Building : MonoBehaviour
{
    public int costInCoins = 20;
    public int costInWood = 20;
    public int costInStone = 20;

    public int timeBuilding;
    public int timeDestroy;

    [Header("Parameters")] 
    public Vector2Int size;
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
            for(int i = 0; i < mesh.materials.Length;i++)
                mesh.materials[i].color = new Color(1,0,0,0.3f);
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
        angle -= 90;
        transform.localEulerAngles = new Vector3(0, angle, 0);
    }
    public void RotateLeft()
    {
        angle += 90;
        transform.localEulerAngles = new Vector3(0,angle,0);
    }

    public void OnDrawGizmos()
    {
        for(int x = 0; x < size.x;x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                if((x+y) % 2 == 0) Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
                else Gizmos.color = new Color(1f,0f,0f,0.3f);
                Gizmos.DrawCube(transform.position + new Vector3(x,0,y), new Vector3(1, 0.1f, 1));
            }
        }
    }
}
