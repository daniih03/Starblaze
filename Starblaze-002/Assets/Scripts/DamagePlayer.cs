using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour

{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !PlayerController.instance.anim.GetBool("Dead"))
        {
           
            PlayerHealthController.instance.DealDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player") && !PlayerController.instance.anim.GetBool("Dead"))
        {
           
            PlayerHealthController.instance.DealDamage();
        }
    }
}
