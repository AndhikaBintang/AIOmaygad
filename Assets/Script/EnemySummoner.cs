using UnityEngine;

public class EnemySummoner : MonoBehaviour
{
    public GameObject miniEnemyPrefab; // prefab musuh kecil
    public float spawnInterval = 5f;   // tiap 5 detik spawn
    public int maxMiniEnemies = 3;     // batas jumlah musuh kecil aktif
    public float spawnRadius = 2f;     // jarak spawn dari induk

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnMiniEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnMiniEnemy()
    {
        // Hitung berapa musuh kecil aktif di scene
        int activeMiniEnemies = GameObject.FindGameObjectsWithTag("MiniEnemy").Length;

        if (activeMiniEnemies < maxMiniEnemies)
        {
            Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            Instantiate(miniEnemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
