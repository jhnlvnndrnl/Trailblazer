using UnityEngine;
using System.Collections;

// public class PlayerControl : MonoBehaviour
// {
//     public float speed = 5f; // Player speed
//     private Rigidbody2D rb;
//     private Vector2 moveInput;

//     void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         // Read keyboard input (WASD / arrows)
//         float moveX = Input.GetAxisRaw("Horizontal");
//         float moveY = Input.GetAxisRaw("Vertical");

//         moveInput = new Vector2(moveX, moveY).normalized;
//     }

//     void FixedUpdate()
//     {
//         // Move the player
//         rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
//     }
// }


public class PlayerControl : MonoBehaviour
{
    public float speed = 5f; // Player speed
    private Rigidbody2D rb;
    private Vector2 moveInput;

    // Add a flag to stop movement temporarily
    [HideInInspector] public bool canMove = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove) return; // ignore input if movement is disabled

        // Read keyboard input (WASD / arrows)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        if (!canMove) return; // prevent movement
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    // Call this to disable movement for a delay
    public void DisableMovement(float delay)
    {
        StartCoroutine(EnableMovementAfterDelay(delay));
    }

    private IEnumerator EnableMovementAfterDelay(float delay)
    {
        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}