using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Animator")]
    private Animator anim;
    private SpriteRenderer theSR;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    [Header("Proyectiles")]
    public GameObject Bullet;
    private float cd;

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
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
        } else if(theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > cd + 0.75f)
        {
            shoot();
            cd = Time.time;
        }
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
