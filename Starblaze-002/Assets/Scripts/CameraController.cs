using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBg, midBg;

    public float minHeight, maxHeight;

    private Vector2 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x + 2f, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBg.position = farBg.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        midBg.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * 0.5f;

        lastPos = transform.position;
    }
}
