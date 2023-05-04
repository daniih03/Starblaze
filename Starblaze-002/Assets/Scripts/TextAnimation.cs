using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{

    public GameObject Text;

    private bool isActive;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        if(!isActive)
        {
            TextAnim();
        }
    }
public void TextAnim()
{
     StartCoroutine(Anim());
}

IEnumerator Anim()
{
    isActive = true;

    Text.SetActive(true);
    
    yield return new WaitForSeconds(1f);

    Text.SetActive(false);

    yield return new WaitForSeconds(1f);

    isActive = false;

}
   
}
