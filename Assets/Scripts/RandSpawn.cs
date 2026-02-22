using UnityEngine;

public class RandSpawn : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject[] prefabs;

    [Header("Spawn Area")]
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(10f, 1f);
    [SerializeField] private Vector2 spawnAreaOffset = Vector2.zero;

    [Header("Timing")]
    [SerializeField] private float spawnInterval = 1.5f;

    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Spawn();
            timer = spawnInterval;
        }
    }

    private void Spawn()
    {
        if (prefabs == null || prefabs.Length == 0) return;

        Vector3 position = GetRandomPosition();
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

        Instantiate(prefab, position, Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 center = transform.position + (Vector3)spawnAreaOffset;

        float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

        return center + new Vector3(randomX, randomY, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 center = transform.position + (Vector3)spawnAreaOffset;
        Gizmos.DrawWireCube(center, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0.1f));
    }
}