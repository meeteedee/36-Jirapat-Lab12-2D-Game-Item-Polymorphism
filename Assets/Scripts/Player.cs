using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 7f;
    public Transform groundCheck;     // จุดเช็คพื้น (วางใต้เท้าตัวละคร)
    public float checkRadius = 0.2f;  // รัศมีเช็คพื้น
    public LayerMask groundLayer;     // Layer พื้น

    private Rigidbody2D rb;
    private float inputX;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        // กระโดด (เช็คว่าติดพื้น)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // เดิน
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        // เช็คพื้น
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        // ให้เห็นจุดเช็คพื้นใน Scene
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}