using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public float BounceLength, BounceForce, BounceCounter;

   

    public GameObject Player;

    private Rigidbody2D theRB;
   
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        Bounce();
      
    }

   
    void Update()
    {
        BounceCounter = BounceCounter - Time.deltaTime;
        if(BounceCounter >=0)
        {
            int direction = Random.Range(-1, 1);

            theRB.velocity = Vector2.up * BounceForce;
        } else theRB.velocity = new Vector2(0, theRB.velocity.y);
        
        

        
    }

    public void Bounce()
    {
        BounceCounter = BounceLength;
        
    }

   

    


}
