using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves forward
    public float jumpForce = 10f; // Force applied when the player jumps
    public Transform groundCheck; // Reference to a GameObject used for checking if the player is grounded
    public LayerMask groundLayer; // Layer mask to determine what objects are considered ground
    public float groundCheckRadius = 0.2f; // Radius of the ground check

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // Move the player forward
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // Jump when the player presses the jump button (e.g., Space key) and is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpForce);
        }
    }
    public void stop()
    {
        moveSpeed = 0f;
    }
}
