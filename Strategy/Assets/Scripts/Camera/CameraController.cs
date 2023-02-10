using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minPosX, maxPosX;
    [Range(0.5f, 9)] public float sensivity;

    private Vector3 touthPos;
    private Vector3 direction;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touthPos = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z));
        }

        if (Input.GetMouseButton(0))
        {
            direction = touthPos - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z));

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosX, maxPosX) - direction.x / 50 * sensivity,
                transform.position.y, transform.position.z);
        }
    }
}
