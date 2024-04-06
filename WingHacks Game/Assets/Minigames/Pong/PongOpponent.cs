using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongOpponent : MonoBehaviour
{
    [SerializeField] GameObject puck;
    [SerializeField] int level;
    [SerializeField] int movementSpeed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 direction = new Vector3(0.0f, puck.transform.position.y - rb.position.y);
        rb.MovePosition(rb.position + direction.normalized * movementSpeed * 5 * Time.fixedDeltaTime);
    }
}
