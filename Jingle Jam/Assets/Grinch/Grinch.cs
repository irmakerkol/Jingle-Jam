using UnityEngine;

public class Grinch : MonoBehaviour
{
    public float speed = 10.0f; // The speed at which the Grinch moves
    public GameObject rockPrefab; // The prefab for the rock that the Grinch throws
    public float throwInterval = 1.0f; // The interval at which the Grinch throws rocks
    public AudioClip evilLaugh; // The sound that plays when the Grinch throws a rock
    public float rockSpeed = 15.0f; // The speed at which the rock travels

    private float lastThrowTime; // The time at which the Grinch last threw a rock
    [SerializeField] AudioSource audioSource; // The AudioSource component for playing sounds
    [SerializeField] Santa santa; // The Santa object in the game
    private bool gameOver; // Whether the game is over


    private void Update()
    {
        // Check if it's time to throw a rock
        if (Time.time - lastThrowTime > throwInterval && !gameOver)
        {
            // Throw a rock
            ThrowRock();
        }
    }

    private void ThrowRock()
    {
        // Create a new rock object
        GameObject rockObject = Instantiate(rockPrefab, transform.position, Quaternion.identity);
        Rock rock = rockObject.GetComponent<Rock>();

        // Set the velocity of the rock
        Vector2 direction = santa.transform.position - transform.position;
        direction.Normalize();
        rock.velocity = direction * rockSpeed;

        // Play the throw sound
        audioSource.PlayOneShot(evilLaugh);

        // Update the time at which the Grinch last threw a rock
        lastThrowTime = Time.time;
    }
}