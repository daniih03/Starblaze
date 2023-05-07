using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
[Header("SFX")]
    public AudioSource[] soundEffects;
[Header("Music")]
    public AudioSource bgm, levelEndMusic;
[Header("Counters")]
    public float fadetime;
    private bool EndLevel;




   
private void Awake()
{
    instance =this;
}


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
            if(EndLevel)
            {
                bgm.volume = Mathf.MoveTowards(bgm.volume, 0f, fadetime * Time.deltaTime);
                if(bgm.volume <=0)
                {
                    bgm.Stop();
                    bgm.volume =1;
                    EndLevel = false;
                    
                }
            }
        
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }

    public void MusicVolumeDown()
    {
        
        EndLevel=true;
    
    }

}
