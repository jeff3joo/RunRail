using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private GameObject pauseMenuPanel;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float laneChangeSpeed = 5f;
    [SerializeField] private float maxJumpDistance = 500f;

    public static PlayerController instance;

    private bool isGameOver;
    private bool isGamePaused;
    private Vector3 lastPosition;
    private float laneDistance = 3f;
    private float distanceTraveled = 0f;
    private float currentLanePosition = 0f;
    private bool wasGroundedLastFrame = true;
    private float nextSpeedIncreaseThreshold = 100f;
    private int lane = 0; // -1:left, 0:middle, 1:right

    void Awake() {
        instance = this; 
    }
    void Start() {
        Time.timeScale = 1;
        lastPosition = transform.position;
        currentLanePosition = transform.position.x;
        isGameOver = false;
    }

    public void SetGameOverPanel(bool gameOver) {
        gameOverPanel.SetActive(gameOver);
    }

    void Update() {
        if (isGameOver || isGamePaused) return;

        Move();
        TrackDistance();

        bool isPlayerGrounded = IsPlayerGrounded();
        CheckGroundState(isPlayerGrounded);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp) && isPlayerGrounded) {
            Jump();
        }

    }

    public void PauseGame() {
        isGamePaused = true;
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame() {
        isGamePaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Move()
    {

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft) && lane > -1) lane--;
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight) && lane < 1) lane++;

        if (Input.GetKeyDown(KeyCode.Escape)) PauseGame();

        float targetXPosition = lane * laneDistance;
        currentLanePosition = Mathf.Lerp(currentLanePosition, targetXPosition, laneChangeSpeed * Time.deltaTime);

        Vector3 newPosition = transform.position;
        newPosition.x = currentLanePosition;
        transform.position = newPosition;

        Vector3 velocity = rigidBody.linearVelocity;
        velocity.z = speed;
        rigidBody.linearVelocity = velocity;
    }

    bool IsPlayerGrounded()
    {
        Vector3 raycastOrigin = transform.position;
        raycastOrigin.y += 0.1f;
        return Physics.Raycast(raycastOrigin, Vector3.down, 0.1f, groundLayerMask);
    }

    void CheckGroundState(bool isPlayerGrounded)
    {
        if (isPlayerGrounded && !wasGroundedLastFrame)
        {
            animator.SetBool("IsJumping", false);
        }
        wasGroundedLastFrame = isPlayerGrounded;
    }

    void Jump()
    {
        animator.SetBool("IsJumping", true);
        rigidBody.AddForce(Vector3.up * maxJumpDistance);
    }

    void TrackDistance()
    {
        float distanceThisFrame = Vector3.Distance(transform.position, lastPosition);
        distanceTraveled += distanceThisFrame;
        lastPosition = transform.position;

        UIManager.instance.UpdateScore((int)distanceTraveled);
        
        if (distanceTraveled >= nextSpeedIncreaseThreshold && speed < 40)
        {
            speed += 0.5f;
            nextSpeedIncreaseThreshold += 100f;
        }
    }

    public float GetDistanceTraveled()
    {
        return distanceTraveled;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "Obstacle") return;
        isGameOver = true;
        SetGameOverPanel(true);
        Time.timeScale = 0;
        UIManager.instance.SaveHighScore();
    }
}
