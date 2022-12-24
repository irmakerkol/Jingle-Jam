using UnityEngine;

public class Santa : MonoBehaviour
{
    public float speed = 10.0f; // The speed at which Santa moves
    public float tilt = 4.0f; // The tilt of the Santa sprite when he moves
    public float xMin, xMax, yMin, yMax; // The boundaries of the screen
    public AudioClip deathSound; // The sound that plays when Santa dies
    public GameObject presentPrefab; // The prefab for the present that Santa drops
    public float presentInterval = 1.0f; // The interval at which Santa drops presents
    public AudioClip presentSound; // The sound that plays when Santa drops a present

    private float lastPresentTime; // The time at which Santa last dropped a present
    [SerializeField] AudioSource audioSource; // The AudioSource component for playing sounds
    [SerializeField] Rigidbody2D rigidbody; // The Rigidbody2D component for Santa
    private bool gameOver; // Whether the game is over

    private void Update()
    {
        // Check if it's time to drop a present
        if (Time.time - lastPresentTime > presentInterval && !gameOver)
        {
            // Drop a present
            DropPresent();
        }
    }

    private void DropPresent()
    {
        // Create a new present object
        GameObject presentObject = Instantiate(presentPrefab, transform.position, Quaternion.identity);
        Present present = presentObject.GetComponent<Present>();

        // Set the velocity of the present to zero
        present.velocity = Vector2.zero;

        // Play the present sound
        audioSource.PlayOneShot(presentSound);

        // Update the time at which Santa last dropped a present
        lastPresentTime = Time.time;
    }

    private void FixedUpdate()
    {
        // Get the horizontal and vertical input axes
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Set the velocity of Santa based on the input axes
        Vector2 movement = new Vector2(moveHorizontal, 0f);
        rigidbody.velocity = movement * speed;

        // Clamp Santa's position to the boundaries of the screen
        rigidbody.position = new Vector2(
            Mathf.Clamp(rigidbody.position.x, xMin, xMax),
            Mathf.Clamp(rigidbody.position.y, yMin, yMax)
        );

    }
}
