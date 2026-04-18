using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void ReStartGame() {
        SceneManager.LoadScene("Level");
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void PauseGame() {
        PlayerController.instance.PauseGame();
    }

    public void ResumeGame() {
        PlayerController.instance.ResumeGame();
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }

}
