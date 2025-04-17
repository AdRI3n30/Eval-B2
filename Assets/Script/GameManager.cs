using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;




public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;

    public GameObject gameUI;
    public GameObject gameOverUI;
    

    void Awake()
    {
        if (Instance == null) Instance = this;
        Time.timeScale = 1;
        score = 0;
        UpdateScoreText();
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        finalScoreText.text = "Score : " + score.ToString();
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
