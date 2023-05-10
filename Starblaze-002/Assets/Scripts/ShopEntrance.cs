using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopEntrance : MonoBehaviour
{
    public GameObject instantiate;

    GameObject temp;

    private bool nearPlayer;

   


  public void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Player"){
        nearPlayer = true;
        temp = Instantiate(instantiate, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
    }
  }

  public void OnTriggerExit2D(Collider2D other)
  {
   if(other.tag == "Player"){
        nearPlayer = false;
        Destroy(temp);
    }
  }

  void Update()
  {
    if(nearPlayer && Input.GetButtonDown("Action"))
    {
        LevelManager.instance.ShopEnter();
    }
  }
}
