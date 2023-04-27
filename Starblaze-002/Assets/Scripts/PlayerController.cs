using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer theSR;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    [Header("Proyectiles")]
    public GameObject Bullet;
    private float cd;

    public float knockbackLength, knockbackForce;
    private float knockbackCounter;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();

        
    }

    void Update()
    {
        if(knockbackCounter <= 0 && !anim.GetBool("Dead"))
        {
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, 0.2f, whatIsGround);

            if(isGrounded)
            {
                canDoubleJump = true;
            }

            if(Input.GetButtonDown("Jump"))
            {
                if(isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                } else
                {
                    if(canDoubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }
            }

            if(theRB.velocity.x < 0)
            {
                theSR.flipX = true;
            }
            else if(theRB.velocity.x > 0)
            {
                theSR.flipX = false;
            }
        }
        else if (knockbackCounter >= 0)
        {
            knockbackCounter -= Time.deltaTime;
            if(!theSR.flipX)
            {
                 
                theRB.velocity = new Vector2(-knockbackForce, theRB.velocity.y);
            }
            else
            {
                
                theRB.velocity = new Vector2(knockbackForce, theRB.velocity.y);
            }
        } else theRB.velocity = new Vector2(0, 0);

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > cd + 0.75f)
        {
            shoot();
            cd = Time.time;
        }
    }

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        theRB.velocity = new Vector2(0f, knockbackForce);
    }

    private void shoot()
    {
        Vector3 direction;
        if(!theSR.flipX)
        {
            direction = Vector2.right;
            GameObject bullet = Instantiate(Bullet, new Vector3(transform.position.x + 1 * 0.725f, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);
        }
        else if(theSR.flipX)
        {
            direction = Vector2.left;
            GameObject bullet = Instantiate(Bullet, new Vector3(transform.position.x - 1 * 0.725f, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);
        }
    }
}
