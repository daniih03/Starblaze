using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool movingRight;
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;

    public GameObject exp;

    public float ChancetoDrop;
    public GameObject Collectible;


    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

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
                Instantiate(Collectible, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
