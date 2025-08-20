using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          
    private Rigidbody2D rb;               
    private Vector2 moveInput;            
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // ambil sprite renderer
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;

        // Flip sprite player berdasarkan arah X
        if (moveX > 0)
            spriteRenderer.flipX = false; // menghadap kanan
        else if (moveX < 0)
            spriteRenderer.flipX = true;  // menghadap kiri
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
