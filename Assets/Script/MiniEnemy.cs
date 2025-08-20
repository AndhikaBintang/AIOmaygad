using UnityEngine;

public class MiniEnemy : MonoBehaviour
{
    public float speed = 4f; // lebih cepat dari enemy biasa
    public int damage = 5;   // damage kecil

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerHealth hp = col.GetComponent<PlayerHealth>();
            if (hp != null) hp.TakeDamage(1);

            Destroy(gameObject);
            return;
        }

        // hancurkan peluru kalau nabrak selain Enemy
        if (!col.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
