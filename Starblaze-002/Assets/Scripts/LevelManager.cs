using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public float waitToRespawn;

    public Animator anim;

   private void Awake()
   {
    instance=this;
   }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
       
       
                
    }

    IEnumerator RespawnCo()
    {
        //PlayerController.instance.gameObject.SetActive(false);
        PlayerController.instance.Knockback();
        
        PlayerController.instance.anim.SetBool("Dead", true);

        yield return new WaitForSeconds(waitToRespawn);
       PlayerController.instance.theRB.velocity =new Vector2(0.0f , 0.0f); 
       
        //PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.anim.SetBool("Dead", false);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;

         UIController.instance.UpdateHealthDisplay();

        
    }

}
