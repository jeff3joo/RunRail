using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "Player") return;
        UIManager.instance.SaveHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
