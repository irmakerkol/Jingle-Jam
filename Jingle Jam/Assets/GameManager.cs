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

    public void GivePointToSanta()
    {

    }

    public void RemovePointFromSanta()
    {
        // code to update Grinch's score
    }

    public void GivePointToGrinch()
    {

    }

    public void RemovePointFromGrinch()
    {

    }

    public void UpdateLevel()
    {
        // code to update the level
    }
}

