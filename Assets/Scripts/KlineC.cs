using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlineC : MonoBehaviour
{
    [SerializeField] private float runForce = 25f;
    [SerializeField] private float jumpForce = 100f;

    protected Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        bool isGrounded = Mathf.Abs(rb.velocity.y) < Mathf.Epsilon;

        Vector2 moveDir = ReadMovement();
        Vector2 forceDir = new Vector2 (moveDir.x * runForce, 0f);

        if (Mathf.Abs(moveDir.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector3(moveDir.x, 1f, 1f);
        }

        if (isGrounded && moveDir.y > 0f)
        {
            forceDir.y = jumpForce;
        }

        rb.AddRelativeForce(forceDir);
    }

     protected Vector2 ReadMovement()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x--;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x++;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection.y++;
        }

        return moveDirection;
    }
}
