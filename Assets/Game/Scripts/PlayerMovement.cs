using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick moveJoystick;

    private Rigidbody2D rb;
    private float moveH, moveV, speedMove = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movePlayer();
        // movePlayerByKerboard();
    }
    void movePlayerByKerboard()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(moveH, moveV, 0);

        // Set the player's velocity based on input
        rb.velocity = new Vector2(moveH * speedMove, moveV * speedMove);

        if (dir != Vector3.zero)
        {
            // Use LookAt to make the player face the movement direction
            transform.LookAt(transform.position + dir);

            // Set the rotation around the Z-axis to always be zero
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void movePlayer()
    {
        moveH = moveJoystick.Horizontal;
        moveV = moveJoystick.Vertical;
        Vector3 dir = new Vector3(moveH, moveV, 0);

        // Set the player's velocity based on input
        rb.velocity = new Vector2(moveH * speedMove, moveV * speedMove);

        if (dir != Vector3.zero)
        {
            // Use LookAt to make the player face the movement direction
            transform.LookAt(transform.position + dir);

            // Set the rotation around the Z-axis to always be zero
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
