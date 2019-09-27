using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int PointValue = 1;
    
    
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        GameManager.TotalPoints += PointValue;
        // Destroy the whole Block
        Destroy(gameObject);
    }
}
