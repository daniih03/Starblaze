using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    private SpriteRenderer theSR;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
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
        if(other.collider.CompareTag("Hit")) Destroy(gameObject);
    }
}
