using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    private static int grinchScore;

    public TextMeshProUGUI scoreText;

    private static ScoreManager instance;

    private void Awake()
    {
        scoreText.text = "XMAS SPIRIT: " + "%" + score;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static ScoreManager GetInstance()
    {
        return instance;
    }

    public void GivePointToSanta()
    {
        // Increment Santa's score
        score++;

        // Update the score display
        scoreText.text = "XMAS SPIRIT: "+"%"+ score ;
    }

    public void RemovePointFromSanta()
    {
        // Decrement Santa's score
        score--;

        // Update the score display
        scoreText.text = "XMAS SPIRIT: " + "%" + score;
    }

    public void GivePointToGrinch()
    {
        // Increment Grinch's score
        grinchScore++;

    }

    public void RemovePointFromGrinch()
    {
        // Decrement Grinch's score
        grinchScore--;

    }
}
