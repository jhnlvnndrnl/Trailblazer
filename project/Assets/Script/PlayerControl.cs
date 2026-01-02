using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f; // Player speed
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read keyboard input (WASD / arrows)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
