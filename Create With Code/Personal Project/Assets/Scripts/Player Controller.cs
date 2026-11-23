using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerPlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 15f;
    [SerializeField] private float sprintSpeed = 25f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float groundCheckDistance = 1.1f;

    [Header("Player Controls")]
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction jumpAction;
    [SerializeField] private InputAction sprintAction;

    private Rigidbody playerRb;
    private Vector2 movementInput;
    private bool jumpPressed;

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        sprintAction.Disable();
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();

        if (jumpAction.WasPressedThisFrame())
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (playerRb == null) return;

        bool isGrounded = Physics.Raycast(
            playerRb.position,
            Vector3.down,
            groundCheckDistance
        );

        float currentSpeed = sprintAction.IsPressed()
            ? sprintSpeed
            : speed;

        Vector3 moveDirection =
            transform.forward * movementInput.y +
            transform.right * movementInput.x;

        Vector3 targetVelocity = moveDirection.normalized * currentSpeed;

        playerRb.linearVelocity = new Vector3(
            targetVelocity.x,
            playerRb.linearVelocity.y,
            targetVelocity.z
        );

        if (jumpPressed && isGrounded)
        {
            playerRb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.Impulse
            );
        }

        jumpPressed = false;
    }
}