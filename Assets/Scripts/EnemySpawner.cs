using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public float enemySpeed;

    private float lastSpawnTime;

    public float range = 0.1f;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            float randomY = Random.Range(0f, range);
            Vector3 spawnPosition = new Vector3(10f, randomY - 2.7f, 0f);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
            enemyRigidbody.velocity = Vector2.left * enemySpeed;
            lastSpawnTime = Time.time;
        }
    }
}
