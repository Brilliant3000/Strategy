using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class BuildingProgressBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro; 
    [SerializeField] private Slider slider;
    private float time;
    
    public void Active(Building building, int time)
    {
        transform.position = new Vector3(building.transform.position.x, building.transform.position.y + 1f, building.transform.position.z);
        gameObject.SetActive(true);
        this.time = time;
        slider.maxValue = time;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            textMeshPro.text = Mathf.RoundToInt(time).ToString();
            slider.value = time;
        }
        else
        {
            Inactive();
        }
    }
    private void Inactive()
    {
        gameObject.SetActive(false);
    }
}
