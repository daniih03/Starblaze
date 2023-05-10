using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiendaLevelManager : MonoBehaviour
{

    public string exitScene;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            SceneManager.LoadScene(exitScene);
        }
    }
}
