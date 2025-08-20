using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    public GameObject player;
    public float speed = 3f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player == null) return;
        }

        Vector2 dir = (player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // Flip sprite enemy berdasarkan arah X menuju player
        if (dir.x > 0)
            spriteRenderer.flipX = false; // menghadap kanan
        else if (dir.x < 0)
            spriteRenderer.flipX = true;  // menghadap kiri
    }
}
