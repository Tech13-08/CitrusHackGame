using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public GameManager gm;
    public GameObject leafPrefab;
    public float spawnInterval;
    public float leafSpeed;

    private float lastSpawnTime;

    public float range = 1f;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval && gm.gameRun)
        {
            float randomY = Random.Range(0.5f, range);
            Vector3 spawnPosition = new Vector3(10f, randomY - 2.7f, 0f);
            GameObject leaf = Instantiate(leafPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D leafRigidbody = leaf.GetComponent<Rigidbody2D>();
            leafRigidbody.velocity = Vector2.left * leafSpeed;
            lastSpawnTime = Time.time;
        }
    }
}
