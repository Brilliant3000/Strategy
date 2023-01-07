using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bank : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private int coin = 100;
    [SerializeField] private int maxCoin = 100;

    private void Start()
    {
       	_textMeshPro.text = $"{coin}";
    }

    public int Coin
	{
		get 
		{ 
			return coin; 
		}
		set 
		{
			coin = value;
			coin = Mathf.Clamp(coin, 0, int.MaxValue);
			_textMeshPro.text = $"{coin} / {maxCoin}";
		}
	}

    public void ReturnResources(Building building)
    {
        
    }
}
