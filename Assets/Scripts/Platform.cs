using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        PlatformSpawner.instance.spawnObject();
        ObjectPool.instance.ReturnObject(gameObject);
    }
}
