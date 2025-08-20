using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootCooldown = 1.5f;
    public float shootRange = 5f;

    [Header("Movement Reference")]
    public float moveThreshold = 0.1f;
    private Vector3 lastPosition;

    private float shootTimer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPosition = transform.position;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player == null) return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        float movement = Vector3.Distance(transform.position, lastPosition);
        bool isMoving = movement > moveThreshold;
        lastPosition = transform.position;

        if (distanceToPlayer <= shootRange && !isMoving)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                Shoot();
                shootTimer = shootCooldown;
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        Vector2 direction = (player.transform.position - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * 5f; 
        }
    }
}
