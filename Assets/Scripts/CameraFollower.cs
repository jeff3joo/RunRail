using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    Vector3 camOffset;
    void Start()
    {
        camOffset = transform.position - player.position;
    }

    void Update()
    {
        Vector3 targetPosition = player.position + camOffset;
        targetPosition.x = 0;

        transform.position = targetPosition;
    }
}
