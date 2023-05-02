using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    private SpriteRenderer theSR;

    private float speed;

    private Animator anim;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        speed = Speed;
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;
        if(Direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(Direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void BulletDestroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Ground")) anim.SetBool("Impact", true);
        else if (other.collider.CompareTag("Enemy")) 
        {
            Destroy(gameObject);
            anim.SetBool("Impact", true);
        }
    } 

    
    
        
    
}
