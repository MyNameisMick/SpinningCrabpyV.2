using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    //public float moveSpeed = 3f;
    //[HideInInspector] public Vector3 dir;
    //float hzInput, vInput;
    //CharacterController controller;

    //[SerializeField]float groundOffset;
    //[SerializeField] LayerMask groundMask;
    //Vector3 spherePos;

    //[SerializeField] float gravity = -9.81f;
    //Vector3 velocity;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    controller = GetComponent<CharacterController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    GetDirectionAndMove();
    //    Gravity();
    //}

    //public void GetDirectionAndMove()
    //{
    //    hzInput = Input.GetAxis("Horizontal");
    //    vInput = Input.GetAxis("Vertical");

    //    dir = transform.forward * vInput + transform.right * hzInput;

    //    controller.Move(dir * moveSpeed * Time.deltaTime);
    //}

    //bool isGround()
    //{
    //    spherePos = new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z);

    //    if(Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
    //    return false;
    //}

    //void Gravity()
    //{
    //    if (!isGround()) velocity.y += gravity * Time.deltaTime;
    //    else if (velocity.y < 0) velocity.y = -2;

    //    controller.Move(velocity * Time.deltaTime);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(spherePos, controller.radius - 0.05f);
    //}

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float groundYOffset = 0.1f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector3 movementDirection;
    private Vector3 spherePosition;

    private void Awake()
    {
        // Cache the CharacterController component for performance
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component is missing!");
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        // Calculate movement direction
        GetDirection();

        // Apply gravity
        ApplyGravity();

        // Combine movement and gravity, then move the character
        Vector3 finalMove = movementDirection * moveSpeed + velocity;
        controller.Move(finalMove * Time.deltaTime);
    }

    private void GetDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;
    }

    private bool IsGrounded()
    {
        spherePosition = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        return Physics.CheckSphere(spherePosition, controller.radius - 0.05f, groundMask);
    }

    private void ApplyGravity()
    {
        if (IsGrounded())
        {
            // Reset gravity when grounded
            if (velocity.y < 0)
            {
                velocity.y = -2f; // Slight negative value to ensure contact with the ground
            }
        }
        else
        {
            // Apply gravity over time when not grounded
            velocity.y += gravity * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the ground check sphere in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z),
            controller != null ? controller.radius - 0.05f : 0.5f
        );
    }
}
