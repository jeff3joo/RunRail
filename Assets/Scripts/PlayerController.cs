using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float moveSpeed;

    private float horizontalInput;
    private float distanceTraveled = 0f;
    private Vector3 lastPosition;
    private float nextSpeedIncreaseThreshold = 100f;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        move();
        TrackDistance();
    }

    void move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 forward = new Vector3(0.0f, 0.0f, 1).normalized;
        Vector3 horizontal = new Vector3(horizontalInput * moveSpeed, 0.0f, 0.0f);
        transform.position += ((forward * speed) + horizontal) * Time.deltaTime;
    }

    void TrackDistance()
    {
        float distanceThisFrame = Vector3.Distance(transform.position, lastPosition);
        distanceTraveled += distanceThisFrame;
        lastPosition = transform.position;

        UIManager.instance.UpdateScore((int)distanceTraveled);
        
        if (distanceTraveled >= nextSpeedIncreaseThreshold && speed < 50)
        {
            speed+=0.25f;
            nextSpeedIncreaseThreshold += 100f;
        }
    }

    public float GetDistanceTraveled()
    {
        return distanceTraveled;
    }
}
