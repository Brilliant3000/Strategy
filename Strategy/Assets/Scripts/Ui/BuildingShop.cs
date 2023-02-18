using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingShop : MonoBehaviour
{
    [SerializeField] private BuildingShopItem _item;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private Button closeButton;
    private BuildingConfig[] _buildingsConfig;
    private UIHub _uiHub;

    private void Awake()
    {
        _buildingsConfig = Resources.LoadAll<BuildingConfig>("");
        _uiHub = FindObjectOfType<UIHub>();
        closeButton.onClick.AddListener(ClosePanel);
    }

    private void Start()
    {
        SortCards();
        foreach (BuildingConfig config in _buildingsConfig) 
        {
            if (config.hideInShop == true) continue;

            BuildingShopItem item = Instantiate(_item, _scrollRect.content.transform);
            item.SetValues(config);
            item.shopCardButton.onClick.AddListener(HidePanel);
        }
    }

    private void SortCards()
    {
        foreach (BuildingConfig building in _buildingsConfig)
        {
            for (int i = 1; i < _buildingsConfig.Length; i++)
            {
                if (_buildingsConfig[i - 1].id > _buildingsConfig[i].id)
                {
                    var temp = _buildingsConfig[i - 1];
                    _buildingsConfig[i - 1] = _buildingsConfig[i];
                    _buildingsConfig[i] = temp;
                }
            }
        }
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
        _uiHub.OffSomePanel.Invoke();
    }
    private void HidePanel()
    {
        gameObject.SetActive(false);
        _uiHub.OffPanelWithoutSelectManager.Invoke();
    }

}
