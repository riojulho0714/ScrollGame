using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        this.animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (sr.isVisible)
        {
            if (checkCollision.isOn)
            {
                rightTleftF = !rightTleftF;
            }
            int xVector = -1;

            if (rightTleftF)
            {
                xVector = 1;
                transform.localScale = new Vector3(-7, 7, 7);
            }
            else
            {
                transform.localScale = new Vector3(7, 7, 7);
            }
            rb.velocity = new Vector2(xVector * speed * -1, rb.velocity.y);
        }
    }
}

 