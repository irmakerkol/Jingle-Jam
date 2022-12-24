using UnityEngine;

public class Present : MonoBehaviour
{
    public Vector2 velocity; // The velocity of the present

    [SerializeField] Rigidbody2D rb; // The Rigidbody2D component for the present

    private void Update()
    {
        // Move the present based on its velocity
        rb.velocity = -velocity;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the present hit a house
        House house = collider.gameObject.GetComponentInParent<House>();
        if (house != null)
        {
            // Check if the house is good or bad
            if (house.type == House.HouseType.Good)
            {
                ScoreManager.GetInstance().GivePointToSanta();
                ScoreManager.GetInstance().RemovePointFromGrinch();

            }
            else
            {
                ScoreManager.GetInstance().RemovePointFromSanta();
                ScoreManager.GetInstance().GivePointToGrinch();

            }

            // Destroy the present
            Destroy(gameObject);
        }
    }
}
