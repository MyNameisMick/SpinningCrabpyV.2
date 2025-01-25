using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed, jump;
    Vector2 move;

    public LayerMask mask;
    public Transform Gpoint;
    bool canJump;

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.y * speed);

        if (Physics.Raycast(Gpoint.position, Vector3.down, 0.3f, mask))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }
}
