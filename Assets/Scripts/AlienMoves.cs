using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMoves : MonoBehaviour
{
    // public Transform[] pathPoints;
    public float alienSpeed = 1.0f;
    // private int nearestPoint;
    // private int pathPointIndex = 0;

    Rigidbody2D rgd_bdy;
    // BoxCollider2D boxCollider;

    void Start()
    {
        rgd_bdy = GetComponent<Rigidbody2D>();
        // boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (IsFacingRight())
        {
            rgd_bdy.velocity = new Vector2(alienSpeed, 0.0f);
        }
        else
        {
            rgd_bdy.velocity = new Vector2(-alienSpeed, 0.0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rgd_bdy.velocity.x)), transform.localScale.y);
    }
}
