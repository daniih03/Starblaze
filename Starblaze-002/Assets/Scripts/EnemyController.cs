using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Components")]
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public GameObject EnemyBody;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool movingRight;

    [Header("Instantiates")]
    public GameObject exp;
    public GameObject Collectible;

    [Header("Misc")]

    public float ChancetoDrop;
   

    public static EnemyController instance;

GameObject temp;
    




    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        
        temp = Collectible;

        leftPoint.parent = null;
        rightPoint.parent = null;
    }

    void Update()
    {
        if(movingRight)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

            theSR.flipX = true;

            if(transform.position.x > rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

            theSR.flipX = false;

            if(transform.position.x < leftPoint.position.x)
            {
                movingRight = true;
            }
        }

        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("proyectile"))
        {
              Instantiate(exp, transform.position, Quaternion.identity);

            float dropSelect = Random.Range(0,100);
            if(dropSelect <= ChancetoDrop && PlayerHealthController.instance.currentHealth <PlayerHealthController.instance.maxHealth)
            {
               GameObject colectible = Instantiate(Collectible, transform.position, Quaternion.identity);
            }
            AudioManager.instance.PlaySFX(6);
            CinemachineCamShake.instance.MoverCamara(1f,1f,0.5f);
            EnemyBody.SetActive(false);
            
            

        }
    }


}
