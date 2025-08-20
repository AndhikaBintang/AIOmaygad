using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
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
