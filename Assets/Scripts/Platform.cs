using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour {
    [SerializeField] private GameObject obstacle;
    private void OnTriggerExit(Collider other) {
        PlatformSpawner.instance.spawnObject();
        ObjectPool.instance.ReturnObject(gameObject);
    }

    void Start() {
        SpawnObstacle();
    }

    public void SpawnObstacle() {
        if (obstacle == null) {
            Debug.LogError("Obstacle prefab is not assigned in the Inspector!");
            return;
        }
        int childCount = transform.childCount;
        if (childCount < 5) {
            Debug.LogError($"Platform only has {childCount} children, but SpawnObstacle expects at least 5!");
            return;
        }
        int rand = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(rand).transform;

        GameObject spawnedObstacle = Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        spawnedObstacle.transform.SetParent(transform, worldPositionStays: true);
    }
}