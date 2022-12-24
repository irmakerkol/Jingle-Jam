using UnityEngine;
using TMPro;


public class TimeManager : MonoBehaviour
{
    public float timeLimit = 300.0f;

    public int scoreLimit = 100;
    public TextMeshProUGUI timeText;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;

    }

    private void Update()
    {
        // Calculate the elapsed time
        float elapsedTime = Time.time - startTime;

        // Calculate the remaining time
        float remainingTime = timeLimit - elapsedTime;

        // Update the time display
        timeText.text = "Time: " + Mathf.FloorToInt(remainingTime);


        // Check if the time limit has been reached
        if (remainingTime <= 0)
        {
            // Time limit reached, player loses
            Debug.Log("You lose!");
        }

        // Check if the score limit has been reached
        if (ScoreManager.score >= scoreLimit)
        {
            // Score limit reached, player wins
            Debug.Log("You win!");
        }
    }
}
