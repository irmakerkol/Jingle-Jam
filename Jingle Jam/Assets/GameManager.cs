using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager: MonoBehaviour
{
    private int score;
    private int grinchScore;

    [SerializeField]
    private TextMeshProUGUI scoreText, grinchScoreText;

    private static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        score = 0;
        grinchScore = 1000;

        if(scoreText != null)
        {
            scoreText.text = "XMAS Spirit: " + score;
            grinchScoreText.text = "Grinch Score: " + grinchScore;
        }
  

    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GivePointToSanta()
    {
        // Increment Santa's score
        score++;

        // Update the score display
        scoreText.text = "XMAS Spirit: " + score;
    }

    public void RemovePointFromSanta()
    {
        // Decrement Santa's score
        score--;

        // Update the score display
        scoreText.text = "XMAS Spirit: " + score;
    }

    public void GivePointToGrinch()
    {
        // Increment Grinch's score
        grinchScore++;

        // Update the score display
        grinchScoreText.text = "Grinch Score: " + grinchScore;
    }

    public void RemovePointFromGrinch()
    {
        // Decrement Grinch's score
        grinchScore--;

        // Update the score display
        grinchScoreText.text = "Grinch Score: " + grinchScore;

    }

}

