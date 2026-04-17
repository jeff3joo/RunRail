using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] private GameObject platform;
    Vector3 nextSpawnPoint;
    void Start()
    {
        for (int i = 0; i < 10; i++) {
            spawnObject();
        }
    }

    void Update()
    {
        
    }

    void spawnObject() {
        GameObject temp = Instantiate(platform,nextSpawnPoint,Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}
