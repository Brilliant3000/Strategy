using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingProgressBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Slider slider;
    private float maxTime;
    private float time;
    private bool growing;

    public void ActiveBuildMode(Building building, bool growing)
    {
        float constructionTime = building.config.buildingLevels[building.level - 1].constructionTime;

        slider.maxValue = constructionTime;
        maxTime = constructionTime;
        this.growing = growing;
        if (growing)
        {
            time = 0.001f;
        }
        else
        {
            time = constructionTime;
        }
        transform.position = new Vector3(building.transform.position.x,
            building.transform.position.y + 1f, building.transform.position.z);

        gameObject.SetActive(true);
    }

    public void ActiveDestroyMode(Building building, bool growing)
    {
        float timeDestroy = building.config.buildingLevels[building.level - 1].destroyTime;
        slider.maxValue = timeDestroy;
        maxTime = timeDestroy;
        this.growing = growing;
        if (growing)
        {
            time = 0.001f;
        }
        else
        {
            time = timeDestroy;
        }
        transform.position = new Vector3(building.transform.position.x,
            building.transform.position.y + 1f, building.transform.position.z);

        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (growing)
            {
                time += Time.deltaTime;
                if (time >= maxTime)
                    gameObject.SetActive(false);
                textMeshPro.text = Mathf.RoundToInt(maxTime - time).ToString();
            }
            else
            {
                time -= Time.deltaTime;
                if (time <= 0)
                    gameObject.SetActive(false);
                textMeshPro.text = Mathf.RoundToInt(time).ToString();
            }

            slider.value = time;
        }
    }
}
