using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{

    public RawImage img;
    Rect rect;

    public string startScene;
    // Start is called before the first frame update
    void Start()
    {
        rect = img.uvRect;
    }

    // Update is called once per frame
    void Update()
    {
        rect.y += Time.deltaTime/10;
        img.uvRect = rect;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
