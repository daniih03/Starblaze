using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !PlayerController.instance.anim.GetBool("Dead"))
        {
            LevelManager.instance.RespawnPlayerF();

        }
    }
 
}
