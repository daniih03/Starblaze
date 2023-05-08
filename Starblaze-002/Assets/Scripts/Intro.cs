using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public string menu;
    
    void Start()
    {
        StartCoroutine(intro());
    }

    
    IEnumerator intro()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(menu);
    }
}
