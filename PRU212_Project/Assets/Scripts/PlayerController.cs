using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public int maxJumpCount = 2;

    private Rigidbody2D rb;
    private int jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            Jump();
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpCount--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            jumpCount = maxJumpCount;
        }
    }
}
