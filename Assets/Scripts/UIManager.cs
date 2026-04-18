using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int currentScore = 0;
    private int highScore = 0;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
        LoadHighScore();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void UpdateScore(int distance)
    {
        currentScore = distance;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        string displayText = "";

        if (highScore > 0)
        {
            displayText = "High Score: " + highScore + "\n";
        }

        displayText += "Score: " + currentScore;
        scoreText.text = displayText;
    }

    public void SaveHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateScoreDisplay();
        }
    }
}
