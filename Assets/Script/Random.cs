using System.Collections;
using UnityEngine;

public class InfinitePrefabSpawner : MonoBehaviour
{
    [SerializeField] public GameObject prefab; // Prefab cần spawn
    [SerializeField] public float initialSpawnDelay = 2f; // Thời gian spawn ban đầu
    [SerializeField] public float minSpawnDelay = 0.5f; // Thời gian spawn nhỏ nhất
    [SerializeField] public float spawnDelayDecreaseRate = 0.05f; // Tốc độ giảm spawn delay
    [SerializeField] public float spawnAccelerationInterval = 5f; // Mỗi bao nhiêu giây thì tăng tốc độ

    [SerializeField] public float minX = -2.6f;
    [SerializeField] public float maxX = 2.8f;
    [SerializeField] public float fixedY = 6.3f;

    [SerializeField] public float minGravity = 0.5f; // Giá trị trọng lực nhỏ nhất
    [SerializeField] public float maxGravity = 3f; // Giá trị trọng lực lớn nhất

    private float currentSpawnDelay; // Spawn delay hiện tại
    private Coroutine spawnCoroutine;
    private int spawnedCount = 0; // Số lượng quả trứng đã spawn

    void Start()
    {
        currentSpawnDelay = initialSpawnDelay; // Khởi tạo delay ban đầu
        StartCoroutine(AccelerateSpawning()); // Tăng tốc độ spawn theo thời gian
        spawnCoroutine = StartCoroutine(SpawnPrefabsForever());
    }

    IEnumerator SpawnPrefabsForever()
    {
        while (true)
        {
            if (spawnedCount < 5)
            {
                // Spawn 1 quả trứng trước khi đạt mốc 5
                SpawnPrefabAtRandomPosition();
            }
            else if (spawnedCount < 10)
            {
                // Spawn 2 quả trứng liên tiếp từ 5 đến dưới 10 quả
                SpawnPrefabAtRandomPosition();
                SpawnPrefabAtRandomPosition();
            }
            else
            {
                // Spawn 3 quả trứng liên tiếp từ 10 quả trở lên
                SpawnPrefabAtRandomPosition();
                SpawnPrefabAtRandomPosition();
                SpawnPrefabAtRandomPosition();
            }

            spawnedCount++; // Tăng số lượng quả trứng đã spawn
            yield return new WaitForSeconds(currentSpawnDelay); // Sử dụng spawn delay hiện tại
        }
    }

    void SpawnPrefabAtRandomPosition()
    {
        if (prefab == null) return;

        // Tạo vị trí spawn ngẫu nhiên
        float spawnX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(spawnX, fixedY, 0);

        // Tạo prefab
        GameObject spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);

        // Lấy Rigidbody2D và thiết lập gravity ngẫu nhiên
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = Random.Range(minGravity, maxGravity);
        }
    }

    IEnumerator AccelerateSpawning()
    {
        while (currentSpawnDelay > minSpawnDelay)
        {
            yield return new WaitForSeconds(spawnAccelerationInterval); // Chờ đến khi tăng tốc độ
            currentSpawnDelay -= spawnDelayDecreaseRate; // Giảm delay
            currentSpawnDelay = Mathf.Max(currentSpawnDelay, minSpawnDelay); // Giới hạn delay tối thiểu
        }
    }

    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }
}
