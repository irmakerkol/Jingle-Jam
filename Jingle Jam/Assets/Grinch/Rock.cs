using UnityEngine;

public class Rock : MonoBehaviour
{
    public Vector2 velocity; // The velocity of the rock

    [SerializeField] Rigidbody2D rigidbody; // The Rigidbody2D component for the rock

    private void Update()
    {
        // Move the rock based on its velocity
        rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the rock hit Santa
        Santa santa = collider.gameObject.GetComponent<Santa>();
        if (santa != null)
        {
            // Remove a point from Santa
            GameManager.GetInstance().RemovePointFromSanta();

            // Add a point to the Grinch
            GameManager.GetInstance().GivePointToGrinch();
        }
    }
}