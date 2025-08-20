using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 1;

    public void TakeDamage(int amount = 1)
    {
        if (health <= 0) return;

        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player mati!");
        Destroy(gameObject);
    }
}
