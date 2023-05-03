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

        
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }

}
