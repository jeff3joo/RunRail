using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour {
    [SerializeField] private GameObject[] obstacle;
    private void OnTriggerExit(Collider other) {
        PlatformSpawner.instance.spawnObject();
        ObjectPool.instance.ReturnObject(gameObject);
    }

    void Start() {
        SpawnObstacle();
    }

    public void SpawnObstacle() {
        if (obstacle == null || obstacle.Length == 0) {
            Debug.LogError("Obstacle prefab array is empty or not assigned in the Inspector!");
            return;
        }
        int childCount = transform.childCount;
        if (childCount < 5) {
            Debug.LogError($"Platform only has {childCount} children, but SpawnObstacle expects at least 5!");
            return;
        }

        int[] spawnIndices = GetTwoRandomSpawnPoints();

        for (int i = 0; i < spawnIndices.Length; i++) {
            int obstacleRandom = Random.Range(0, obstacle.Length);
            Transform spawnPoint = transform.GetChild(spawnIndices[i]).transform;

            GameObject spawnedObstacle = Instantiate(obstacle[obstacleRandom], spawnPoint.position, Quaternion.identity);
            spawnedObstacle.transform.SetParent(transform, worldPositionStays: true);
        }
    }

    private int[] GetTwoRandomSpawnPoints() {
        int[] spawnPoints = new int[2];

        // Get 2 spawn unique points
        spawnPoints[0] = Random.Range(2, 5);
        do {
            spawnPoints[1] = Random.Range(2, 5);
        } while (spawnPoints[1] == spawnPoints[0]);

        return spawnPoints;
    }
}