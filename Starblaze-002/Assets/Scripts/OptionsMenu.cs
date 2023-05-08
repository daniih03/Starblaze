using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
 [Header("Options")]
 public Slider volumeFX;
 public Slider VolumeMusic;
 public AudioMixer mixer;

 [Header("Panels")]
 public GameObject mainpanel;
 public GameObject optionspanel;



 private void Awake()
 {
    volumeFX.onValueChanged.AddListener(ChangevolumeFX);
    VolumeMusic.onValueChanged.AddListener(ChangeVolumeMusic);
 }

 public void openpanel(GameObject panel)
 {
    mainpanel.SetActive(false);
    optionspanel.SetActive(false);

    panel.SetActive(true);
 }

 public void ChangeVolumeMusic(float v)
 {
    mixer.SetFloat("volMusic", v);
 }

 public void ChangevolumeFX(float v)
 {
    mixer.SetFloat("volFx", v);
 }
}
