using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour
{
public GameObject instantiate;

private Rigidbody2D theSR;

private CircleCollider2D theCC;

public int contador;

private Animator ShopperAnim;

private bool nearPlayer;

GameObject temp;

void Awake()
{
  theSR = GetComponent<Rigidbody2D>();
  theCC = GetComponent<CircleCollider2D>();
  ShopperAnim = GetComponent<Animator>();
}


void Update()
{
  if(contador >=2)
  {

    theSR.velocity = new Vector2(-10, theSR.velocity.y);
    theCC.enabled = false;
    ShopperAnim.SetTrigger("Angry");

  }

  if(nearPlayer && Input.GetButtonDown("Action"))
  {
    LevelManager.instance.ShopEnter();
  }
  
}


  public void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Player"){
       temp = Instantiate(instantiate, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
       nearPlayer = true;
    }

    
    
  }

  public void OnTriggerExit2D(Collider2D other)
  {
   if(other.tag == "Player"){
        Destroy(temp);
        nearPlayer = false;
    }
  }

  public void OnCollisionEnter2D(Collision2D other)
  {
    if(other.collider.CompareTag("proyectile"))
    {
      contador++;
    }
    
  }
}
