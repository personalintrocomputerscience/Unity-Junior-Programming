using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 100f;

    public InputAction moveAction;
    public Vector2 moveInput;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        // We'll move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        // Move the vehicle left/right
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x);
    }
}