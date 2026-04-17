using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] private ObjectPool objectPool;

    Vector3 nextSpawnPoint;

    public static PlatformSpawner instance;
    private void Awake() {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 10; i++) {
            spawnObject();
        }
    }

    public void spawnObject() {
        GameObject temp = objectPool.GetObject(nextSpawnPoint);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}
