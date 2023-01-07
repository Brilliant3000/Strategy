using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minAngleX, maxAngleX;
    public float minAngleY, maxAngleY;
    public float sensivity;

    public float axisX;
    public float axisY;
    Vector3 touthPos;
    Vector3 direction;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touthPos = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.y, Input.mousePosition.x, transform.position.z));
        }  
        
        if(Input.GetMouseButton(0))
        {
            direction = touthPos - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.y, Input.mousePosition.x, transform.position.z));

            axisX = direction.x;
            axisY = direction.y;

            axisX = Mathf.Clamp(axisX, minAngleX, maxAngleX);
            axisY = Mathf.Clamp(axisY, minAngleY, maxAngleY);
            transform.eulerAngles += new Vector3(axisX, axisY, 0);
        }
    }
}
