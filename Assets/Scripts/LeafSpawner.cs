using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public GameManager gm;

    public Ground gr;
    public GameObject leafPrefab;
    public float spawnInterval;
    public float leafSpeed;

    private float lastSpawnTime;

    public float rangeMax = 1f;
    public float rangeMin = 0.5f;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval && gm.gameRun)
        {
            float randomY = Random.Range(rangeMin, rangeMax);
            Vector3 spawnPosition = new Vector3(10f, randomY - 2.7f, 0f);
            GameObject leaf = Instantiate(leafPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D leafRigidbody = leaf.GetComponent<Rigidbody2D>();
            leafRigidbody.velocity = Vector2.left * leafSpeed;
            lastSpawnTime = Time.time;

            rangeMax = gr.rb.position.y + 4.876f + 1f;
            rangeMin = gr.rb.position.y + 4.876f + 0.5f;
        }
    }
}
