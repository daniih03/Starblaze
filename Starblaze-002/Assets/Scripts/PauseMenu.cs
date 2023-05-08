using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseScreen;

    public bool isPaused;

    public string MainMenu;

    public static PauseMenu instance;

    public GameObject optionsmenu;
    public GameObject pausemenu;


    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!optionsmenu.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Escape))
        {
           
            
                PauseUnpause();
            
            
        }
        }
        
        
    }

    public void PauseUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            optionsmenu.SetActive(false);
            
            Time.timeScale = 1f;

        }   else 
    {
        isPaused = true;
        pauseScreen.SetActive(true);
        
        Time.timeScale = 0f;
    }
    } 

    public void Mainmenu()
    {
        SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
       Application.Quit();
    }

   
}
