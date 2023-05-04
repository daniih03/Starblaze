using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject ShootFX;
    private float cd;

    public float knockbackLength, knockbackForce;
    private float knockbackCounter;

    public GameObject Heal;

    private CapsuleCollider2D theCC;

    public bool StopInput;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        theCC = GetComponent<CapsuleCollider2D>();

        
    }

    void Update()
    {
        if(!PauseMenu.instance.isPaused && !StopInput) 
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
                    AudioManager.instance.PlaySFX(2);
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
        } else theRB.velocity = new Vector2(0, theRB.velocity.y);
        }
       

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Fire1"))
        {
            if(Time.time > cd + 0.75f && !LevelManager.instance.SafeZone)
            {
                shoot();
            cd = Time.time;
            }
            
        }

        if(anim.GetBool("Dead"))
        {
            theCC.size = new Vector2(0.36f, 0.6684647f);
            
        } else
        {
            theCC.size = new Vector2(0.6684647f, 0.9640899f);
           
        } 
    }

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        theRB.velocity = new Vector2(0f, knockbackForce);
    }

    private void shoot()
    {
        AudioManager.instance.PlaySFX(5);
        Vector3 direction;
        if(!theSR.flipX)
        {
            direction = Vector2.right;
            GameObject bullet = Instantiate(Bullet, new Vector3(transform.position.x + 1 * 0.725f, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);
            Instantiate(ShootFX, new Vector3(transform.position.x + 1 * 0.725f, transform.position.y - 0.15f, transform.position.z), Quaternion.identity);
        }
        else if(theSR.flipX)
        {
            direction = Vector2.left;
            GameObject bullet = Instantiate(Bullet, new Vector3(transform.position.x - 1 * 0.725f, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);
            Instantiate(ShootFX, new Vector3(transform.position.x - 1 * 0.725f, transform.position.y - 0.15f, transform.position.z), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limite"))
        {
            CameraController.instance.StopFollow = true;
        } 

       

    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Limite"))
        {
            CameraController.instance.StopFollow = false;
        } 

    }
}
