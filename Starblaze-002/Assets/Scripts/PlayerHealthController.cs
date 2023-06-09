using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;
    public float invincibleCounter;

    private SpriteRenderer theSR;

    public GameObject HB;

    private Animator HBanim;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();

       HBanim = HB.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
            AudioManager.instance.PlaySFX(4);
            CinemachineCamShake.instance.MoverCamara(10f,5f,0.2f);
           
            HBanim.SetBool("IsFullHp", false);
            HBanim.SetTrigger("HalfDown");
            currentHealth--;
            PlayerController.instance.anim.SetTrigger("hurt");

            if(currentHealth <= 0)
            {
                HBanim.SetTrigger("Empty");
                currentHealth = 0;
                invincibleCounter = 0;
                UIController.instance.WhiteFlash();
                LevelManager.instance.RespawnPlayerD();
                
            }
            else
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);

                PlayerController.instance.Knockback();
            }

           // UIController.instance.UpdateHealthDisplay();
        }
    }


    public void HealPlayer()
    {
         HBanim.SetTrigger("Full");
        
        currentHealth++;
        if(currentHealth >= maxHealth)
        {
            currentHealth =maxHealth;
        }

       // UIController.instance.UpdateHealthDisplay();
    }
}
