using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class FlappyBirdPlayer : MonoBehaviour
{
    [SerializeField] GameManager_FlappyBird gm;
    [SerializeField] float jumpHeight = 5.0f;
    [SerializeField] float gravity = 1.0f;
    bool isInControl = false;
    bool isWaiting = true;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
    }

    private void OnJump()
    {
        if(isInControl)
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0.0f);
        if(isWaiting)
        {
            gm.PlayerStartMovement();
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0.0f);
            isWaiting = false;
            rb.gravityScale = gravity;
            isInControl = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        isInControl = false;
        gm.GameReset();
    }

    public void StartWaiting()
    {
        isWaiting = true;
        rb.gravityScale = 0.0f;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f,0.0f,0.0f);
    }
}
