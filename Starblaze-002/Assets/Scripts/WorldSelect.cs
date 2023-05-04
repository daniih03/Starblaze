using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelect : MonoBehaviour
{
public bool nearPlayer, popup;

public int World;

public GameObject PopUp;

GameObject temp;


   public void OnTriggerEnter2D(Collider2D other)
   {
    if(other.tag == "Player" )
        {
            nearPlayer =true;
            temp = Instantiate(PopUp, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
            
            
        } 
   }
    
    public void OnTriggerExit2D(Collider2D other)
   {
    if(other.tag == "Player" )
        {
            nearPlayer =false;
            Destroy(temp);
        } 
   }

    public void Update()
    {
        
        if(nearPlayer && Input.GetButtonDown("Action"))
        {
            LevelManager.instance.EndLevel(World);
        }
    }
}
