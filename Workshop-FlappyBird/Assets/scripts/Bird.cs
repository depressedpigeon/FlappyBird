using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 30f;
    
    public LayerMask obstacleLayer;
    public GameObject gameManager;
    private Rigidbody2D rb;
    private Animator animator;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        // Check for jump input
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Apply gravity
        rb.AddForce(Vector2.down * rb.gravityScale);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
 

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Game over
        }
    }

    void Jump()
    {
        animator.SetTrigger("jump");
        rb.velocity = Vector2.up * jumpForce;
    }
}
