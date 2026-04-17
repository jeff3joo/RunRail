using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();
    private HashSet<GameObject> activeObjects = new HashSet<GameObject>();

    public static ObjectPool instance;

    private void Awake()
    {
        instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            availableObjects.Enqueue(obj);
        }
    }

    public GameObject GetObject(Vector3 position)
    {
        GameObject obj;

        obj = availableObjects.Count > 0 ? availableObjects.Dequeue() : Instantiate(prefab);

        obj.transform.position = position;
        obj.SetActive(true);
        activeObjects.Add(obj);

        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        activeObjects.Remove(obj);
        availableObjects.Enqueue(obj);
    }
}
