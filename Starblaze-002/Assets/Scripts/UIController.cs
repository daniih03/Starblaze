using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image HealthBar1, HealthBar2;

    public Sprite fullBar, emptyBar;

    public TextMeshProUGUI gemText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateGemCount();
    }

    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        
        switch(PlayerHealthController.instance.currentHealth)
        {
            case 2:
                HealthBar1.sprite = fullBar;
                HealthBar2.sprite = fullBar;
                break;
            case 1:
                HealthBar1.sprite = fullBar;
                HealthBar2.sprite = emptyBar;
                break;
            case 0:
                HealthBar1.sprite = emptyBar;
                HealthBar2.sprite = emptyBar;
                break;
            default:
                HealthBar1.sprite = emptyBar;
                HealthBar2.sprite = emptyBar;
                break;
        }
    }

    public void UpdateGemCount()
    
    {
        gemText.text = LevelManager.instance.gemsCollected.ToString();
    }
}
