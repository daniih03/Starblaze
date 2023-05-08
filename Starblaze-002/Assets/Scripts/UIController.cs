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

    public Image FadeScreen, Whiteflash;



    public float fadeSpeed;
    public bool ShouldFadeToBlack, ShouldFadeFromBlack, ShouldWhiteFlash;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateGemCount();
        FadeFromBlack();
    
    }

    void Update()
    {
        if(ShouldFadeToBlack)
        {
            FadeScreen.color = new Color(FadeScreen.color.r, FadeScreen.color.g, FadeScreen.color.b, Mathf.MoveTowards(FadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(FadeScreen.color.a == 1f)
            {
                ShouldFadeToBlack = false;
            }
        } 

        if(ShouldFadeFromBlack)
        {
            FadeScreen.color = new Color(FadeScreen.color.r, FadeScreen.color.g, FadeScreen.color.b, Mathf.MoveTowards(FadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(FadeScreen.color.a == 0f)
            {
                ShouldFadeFromBlack = false;
            }
        } 
        if (ShouldWhiteFlash)
            {
             Whiteflash.enabled = true;   
       
             Whiteflash.color = new Color(Whiteflash.color.r, Whiteflash.color.g, Whiteflash.color.b, Mathf.MoveTowards(Whiteflash.color.a, 0f, 8f * Time.deltaTime));

             if(Whiteflash.color.a == 0f)
             {
               Whiteflash.enabled= false;
               Whiteflash.color = new Color(Whiteflash.color.r, Whiteflash.color.g, Whiteflash.color.b, 1f);
               ShouldWhiteFlash =false;
             }
            }
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

    public void FadeToBlack()
    {
        ShouldFadeToBlack = true;
        ShouldFadeFromBlack = false;
    }
    public void FadeFromBlack()
    {
        ShouldFadeToBlack = false;
        ShouldFadeFromBlack = true;
    }

    public void WhiteFlash()
    {
        Whiteflash.color = new Color(Whiteflash.color.r, Whiteflash.color.g, Whiteflash.color.b, 1f);     
        ShouldWhiteFlash = true;
            
        
    }
}
