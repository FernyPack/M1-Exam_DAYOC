using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject Exit;
    public int totalTargets;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ExitGame()
        {
            Application.Quit(); 
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

    public void AddScore(int amount)
    {
        score += amount;
        totalTargets--;

        UpdateUI();

        if (totalTargets <= 0)
        {
            WinGame();
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.SetActive(true);
        Exit.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void WinGame()
    {
        Time.timeScale = 0;
        winText.SetActive(true);
        Exit.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}