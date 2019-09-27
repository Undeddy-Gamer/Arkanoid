using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    //Movement Speed
    public float speed = 150;

    //create a ridgid body in start so we do not need to continually retreive it
    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");
        // Set speed of the Racket
        rigid.velocity = Vector2.right * h * speed;
    }

}
