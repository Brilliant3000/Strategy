using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class HarvestSign : SignBaseUI
{
    public Button takeHurvestButton;
    [SerializeField] private float size = 0.45f;

    private void Start()
    {
        FindOptimalSize(size);
        FindOptimalAngle();
    }
    private void OnEnable()
    {
        FindOptimalSize(size);
        FindOptimalAngle();
    }
}
