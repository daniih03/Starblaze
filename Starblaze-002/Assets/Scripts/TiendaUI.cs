using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TiendaUI : MonoBehaviour
{

    [Header("Buttons")]
public GameObject RocketLauncher, Boots, Shield, Rifle, Invincible;

[Header("Dialogues")]

public Image RocketlauncherText, BootsText, ShieldText, InvincibleText, RifleText;





    void Update()
    {
       if( EventSystem.current.currentSelectedGameObject == RocketLauncher)
       {
            BootsText.enabled = false;
            ShieldText.enabled = false;
            RifleText.enabled = false;
            InvincibleText.enabled = false;
            RocketlauncherText.enabled = true;

       } else if(EventSystem.current.currentSelectedGameObject == Boots)
       {
             ShieldText.enabled = false;
            RifleText.enabled = false;
            InvincibleText.enabled = false;
            RocketlauncherText.enabled = false;
         BootsText.enabled = true;
       } else if(EventSystem.current.currentSelectedGameObject == Shield)
       {
         RifleText.enabled = false;
         InvincibleText.enabled = false;
         RocketlauncherText.enabled = false;
         BootsText.enabled = false;
         ShieldText.enabled = true;
       }else if(EventSystem.current.currentSelectedGameObject == Invincible)
       {
         RifleText.enabled = false;
        RocketlauncherText.enabled = false;
         BootsText.enabled = false;
         ShieldText.enabled = false;
         InvincibleText.enabled = true;
       }else if(EventSystem.current.currentSelectedGameObject == Rifle)
       {
        RocketlauncherText.enabled = false;
         BootsText.enabled = false;
         ShieldText.enabled = false;
         InvincibleText.enabled = false;
         RifleText.enabled = true;
       } else 
       {
         RocketlauncherText.enabled = false;
         BootsText.enabled = false;
         ShieldText.enabled = false;
         InvincibleText.enabled = false;
         RifleText.enabled = false;
       }

       
    }



    
   public void RocketLauncherbuyFeature(GameObject sold)
   {
    sold.SetActive(true);
    RocketLauncher.SetActive(false);
    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(sold);

   }

   public void BootsBuyFeature(GameObject sold)
   {
    sold.SetActive(true);
    Boots.SetActive(false);
    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(sold);
   }

   public void ShieldBuyFeature(GameObject sold)
   {
    sold.SetActive(true);
    Shield.SetActive(false);
    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(sold);
   }

   public void RifleBuyFeature(GameObject sold)
   {
    sold.SetActive(true);
    Rifle.SetActive(false);
    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(sold);
   }

   public void InvincibleBuyFeature(GameObject sold)
   {
    sold.SetActive(true);
    Invincible.SetActive(false);
    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(sold);
   }
}
