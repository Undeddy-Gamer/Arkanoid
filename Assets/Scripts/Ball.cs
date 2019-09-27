using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Movement Speed
    public float speed = 100.0f;

    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // if it hits the racket
        if (col.gameObject.name == "Racket")
        {
            // Calculate hit Factor
            float x = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            rigid.velocity = dir * speed;
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

}
