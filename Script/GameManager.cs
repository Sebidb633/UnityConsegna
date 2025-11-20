using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private AudioSource doorOpen;
    public int lives;
    public TextMeshProUGUI livesText;
    private bool isMenuOpen = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
            {
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                SceneManager.LoadScene("MenuScene");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
                
        }
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score >= 4)
        {
            doorOpen.Play();
            Destroy(door);
        }
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = lives.ToString();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameScene");
    }
}
