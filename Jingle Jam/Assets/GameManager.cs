using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    private int score;
    private int grinchScore;
    private int level;

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
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void UpdateScore()
    {
        // code to update the score
    }

    public void UpdateGrinchScore()
    {
        // code to update Grinch's score
    }

    public void UpdateLevel()
    {
        // code to update the level
    }
}

