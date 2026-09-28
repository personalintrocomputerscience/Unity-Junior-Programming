using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public InputAction moveAction;
    public Vector2 moveInput;

    void Start()
    {
        moveAction.Enable();
    }

    void FixedUpdate()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        // Get vertical input
        verticalInput = moveInput.y;

        // Move the plane forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Tilt the plane up/down
        transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);
    }
}