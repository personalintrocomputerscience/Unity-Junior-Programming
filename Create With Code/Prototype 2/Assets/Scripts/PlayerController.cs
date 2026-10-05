using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public Vector2 moveInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public GameObject projectilePrefab;

    void Start()
    {
        moveAction.Enable();
    }

    void Update()
    {
        // 1. Move the player FIRST
        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.right * moveInput.x * Time.deltaTime * speed);

        // 2. Check boundaries SECOND (Snaps them back before the frame renders)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    } // Missing brace added here
} // Missing brace added here