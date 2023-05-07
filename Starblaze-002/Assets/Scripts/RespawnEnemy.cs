using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{

    public static RespawnEnemy instance;

    public GameObject[] enemies;
   
    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public void Respawn()
    {
        for(int a = 0; a < enemies.Length; a++){
        transform.GetChild(a).gameObject.SetActive(true);}
    }
}
