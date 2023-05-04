using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public float waitToRespawn;

    public Animator anim;

    public int gemsCollected;

    public string SceneToLoad;

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
    
    public void RespawnPlayerD()
    {
        StartCoroutine(RespawnCoD());
       
       
                
    }

    public void RespawnPlayerF()
    {
        StartCoroutine(RespawnCoF());
       
       
                
    }

    IEnumerator RespawnCoD()
    {
        //PlayerController.instance.gameObject.SetActive(false);
        PlayerController.instance.Knockback();
        
        PlayerController.instance.anim.SetBool("Dead", true);
        AudioManager.instance.PlaySFX(3);

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();

         yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.2f);

         UIController.instance.FadeFromBlack();
        //PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.anim.SetBool("Dead", false);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;

         UIController.instance.UpdateHealthDisplay();
    }
         IEnumerator RespawnCoF()
    {
        PlayerController.instance.gameObject.SetActive(false);
        
        PlayerController.instance.anim.SetBool("Dead", true);
        AudioManager.instance.PlaySFX(3);
        
        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();

         yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.2f);
         
         UIController.instance.FadeFromBlack();
       
        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.anim.SetBool("Dead", false);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;

         UIController.instance.UpdateHealthDisplay();

        
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.StopInput = true;
        CameraController.instance.StopFollow =true;
        yield return new WaitForSeconds(1.5f);

        AudioManager.instance.MusicVolumeDown();

        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneToLoad);
    }

}

