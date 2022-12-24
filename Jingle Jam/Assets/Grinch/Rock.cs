using System.Collections;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Vector2 velocity; // The velocity of the rock
    private int timesGetHitByRock;

    [SerializeField] Rigidbody2D rb; // The Rigidbody2D component for the rock
    
    private void Update()
    {
        // Move the rock based on its velocity
        rb.velocity = velocity;

        StartCoroutine(WaitForDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the rock hit Santa
        Santa santa = collider.gameObject.GetComponent<Santa>();
        if (santa != null)
        {
            // Remove a point from Santa
            ScoreManager.GetInstance().RemovePointFromSanta();

            // Add a point to the Grinch
            ScoreManager.GetInstance().GivePointToGrinch();
            timesGetHitByRock++;
            PlayerPrefs.SetInt("HitByRock", timesGetHitByRock);
            Destroy(gameObject);

        }
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);

    }
}
