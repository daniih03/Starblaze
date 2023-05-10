using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientists : MonoBehaviour
{

    private Rigidbody2D theRB;

    public float Speed;

    private bool semaforo;

    private Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {

    
        theRB = GetComponent<Rigidbody2D>();
        StartPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(anim());
    }


    IEnumerator anim()
    {
        if(!semaforo)
        {
            semaforo = true;
            yield return new WaitForSeconds(Random.Range(1, 8));
            
           theRB.velocity = new Vector2(Speed, 0);

           yield return new WaitForSeconds(16);

           transform.position = StartPos;

           

           semaforo = false;
        
        }
    }
}
