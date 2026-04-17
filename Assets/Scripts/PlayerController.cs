using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Rigidbody Rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float moveSpeed;

    private float horizontalInput;

    void Start() {

    }

    void Update() {
        move();
    }

    void move() {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 forward = new Vector3(0.0f, 0.0f, 1).normalized;
        Vector3 horizontal = new Vector3(horizontalInput * moveSpeed, 0.0f, 0.0f);
        transform.position += (forward + horizontal) * speed * Time.deltaTime;
    }
}
