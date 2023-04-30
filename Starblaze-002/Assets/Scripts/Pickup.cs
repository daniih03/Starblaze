using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool isGem, isHeal;
    private bool isCollected;
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player") && !isCollected)
    {
        if(isGem)
        {
            LevelManager.instance.gemsCollected++;

            isCollected = true;
            Destroy(gameObject);
        }
        if(isHeal)
        {
          if(PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.maxHealth)
          {
            PlayerHealthController.instance.HealPlayer();

            isCollected=true;
            Destroy(gameObject);
          }
        }
    }
  }
}
