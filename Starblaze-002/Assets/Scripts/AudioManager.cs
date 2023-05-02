using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource[] soundEffects;

    public AudioSource bgm, levelEndMusic;

    public float fadetime;

    private float Fadetime;
   
private void Awake()
{
    instance =this;
}


    void Start()
    {
        Fadetime =fadetime;
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerController.instance.anim.GetBool("Dead"))
        {
            Fadetime = Fadetime - Time.deltaTime;
            if(Fadetime <= 0)
            {
                bgm.volume = Mathf.MoveTowards(bgm.volume, 0.01f, 0.05f *Time.deltaTime);
            } 
            
        } else
        {
            Fadetime = fadetime;
            bgm.volume = Mathf.MoveTowards(bgm.volume, 0.05f, 0.1f *Time.deltaTime);
        } 
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }

}
