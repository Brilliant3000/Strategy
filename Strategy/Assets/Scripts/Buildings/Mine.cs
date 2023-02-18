using System.Collections;
using UnityEngine;

public class Mine : Building
{
    [SerializeField] private GameObject _harvestSignPrefab;
    private HarvestSign _harvestSign;
    private Vector3 _posThisObject;
    public int Coins 
    { 
        get
        {
            return resourceCount;
        } 
        private set
        {
            resourceCount = value;
            resourceCount = Mathf.Clamp(resourceCount, -1, config.buildingLevels[level-1].capacity);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(ProduseTimer());
    }

    private void Start()
    {
        _harvestSign = Instantiate(_harvestSignPrefab).GetComponent<HarvestSign>();
        _harvestSign.takeHurvestButton.onClick.AddListener(TakeHarvest);
    }

    IEnumerator ProduseTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(config.buildingLevels[level - 1].productionRate);
            Coins++;
            if(Coins > (config.buildingLevels[level - 1].capacity * 0.1f))
                ShowSignTakeHarvest();
        }
    }

    private void ShowSignTakeHarvest()
    {
        _posThisObject = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        _harvestSign.transform.position = _posThisObject;
        if (_harvestSign.gameObject.activeSelf == false)
            _harvestSign.gameObject.SetActive(true);
            
    }

    public void TakeHarvest()
    {
        _harvestSign.gameObject.SetActive(false);
        Bank.instance.Coin += resourceCount;
        resourceCount = 0;
    }

    private void OnDestroy()
    {
        Destroy(_harvestSign.gameObject);
    }
}
