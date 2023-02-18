using UnityEngine;

public class SignBaseUI : MonoBehaviour
{
    private Vector3 _cameraPosition;

    private void Awake()
    {
        _cameraPosition = Camera.main.transform.position;
    }

    protected void FindOptimalSize(float fixedSize)
    {
        float distance = Vector3.Distance(_cameraPosition, gameObject.transform.position);
        transform.localScale = Vector3.one * distance * fixedSize;
    }

    protected void FindOptimalAngle()
    {
        float sin = Mathf.Sin(_cameraPosition.y - transform.position.y);
        transform.eulerAngles = new Vector3((sin * Mathf.Rad2Deg), 0, 0);
    }
}
