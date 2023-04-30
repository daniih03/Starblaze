using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool isGem, isHeal;
    private bool isCollected;

    public GameObject collectible;
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player") && !isCollected)
    {
        if(isGem)
        {
            LevelManager.instance.gemsCollected++;
            UIController.instance.UpdateGemCount();

            Instantiate(collectible, transform.position, transform.rotation);

            isCollected = true;
            Destroy(gameObject);
        }
        if(isHeal)
        {
          if(PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.maxHealth)
          {
            PlayerHealthController.instance.HealPlayer();

            Instantiate(collectible, transform.position, transform.rotation);
            
            isCollected=true;
            Destroy(gameObject);
          }
        }
    }
  }
}
