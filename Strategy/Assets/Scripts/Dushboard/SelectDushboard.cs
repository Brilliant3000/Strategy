using UnityEngine;

public class SelectDushboard : MonoBehaviour
{
    private GroundElement ground;

    public void Active(GroundElement ground)
    {
        gameObject.SetActive(true);
        this.ground = ground;

        transform.position = new Vector3(ground.transform.position.x,
        ground.transform.position.y + 0.55f, ground.transform.position.z);
    }

    public void Deactive()
    {
        ground = null;
        gameObject.SetActive(false);
    }

}
