using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))] 
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    float rotationSpeed = 5f;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform berralTranform;
    [SerializeField]
    Transform bulletParant;
    [SerializeField]
    float bulletHitMissDistance = 25f;
    [SerializeField]
    float animationSmoothTime = 0.1f;
    [SerializeField]
    float animationPlayTransition = 0.15f;

    private CharacterController controller;
    PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    Transform cameraTranform;

    InputAction moveAction;
    InputAction lookAction;
    InputAction jumpAction;
    InputAction shootAction;

    Animator animator;
    int jumpAnimation;
    int moveXAnimatorParamterId;
    int moveZAnimatorParamterId;

    Vector2 currentAnimationBlendVector;
    Vector2 animationVelocity;

    public NewShakeScript shake;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTranform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["shoot"];
            
        Cursor.lockState = CursorLockMode.Locked;

        animator = GetComponent<Animator>();
        jumpAnimation = Animator.StringToHash("Jump");
        moveXAnimatorParamterId = Animator.StringToHash("MoveX");
        moveZAnimatorParamterId = Animator.StringToHash("MoveZ");
    }

    private void OnEnable()
    {
        shootAction.performed += _ => ShootGun();
    }

    private void OnDisable()
    {
        shootAction.performed -= _ => ShootGun();
    }

    void ShootGun()
    {
        RaycastHit hit;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, berralTranform.position, Quaternion.identity, bulletParant);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        shake.ShakeScreen( 2f, 1f, 0.2f);

        if (Physics.Raycast(cameraTranform.position, cameraTranform.forward, out hit, Mathf.Infinity))
        {
            bulletController.target = hit.point;
            bulletController.hit = true;
        }
        else
        {
            bulletController.target = cameraTranform.position + cameraTranform.forward * bulletHitMissDistance;
            bulletController.hit = false;
        }
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity, animationSmoothTime);
        Vector3 move = new Vector3(currentAnimationBlendVector.x, 0, currentAnimationBlendVector.y);
        move = move.x * cameraTranform.right.normalized + move.z * cameraTranform.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        animator.SetFloat(moveXAnimatorParamterId, currentAnimationBlendVector.x);
        animator.SetFloat(moveZAnimatorParamterId, currentAnimationBlendVector.y);

        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            animator.CrossFade(jumpAnimation, animationPlayTransition);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float targetAngle = cameraTranform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, cameraTranform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}