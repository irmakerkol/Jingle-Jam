using UnityEngine;

public class Present : MonoBehaviour
{
    public Vector2 velocity; // The velocity of the present
    public AudioClip goodSound; // The sound that plays when the present hits a good house
    public AudioClip badSound; // The sound that plays when the present hits a bad house

    [SerializeField] Rigidbody2D rigidbody; // The Rigidbody2D component for the present
    [SerializeField] AudioSource audioSource; // The AudioSource component for playing sounds

    private void Update()
    {
        // Move the present based on its velocity
        rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the present hit a house
        House house = collider.gameObject.GetComponent<House>();
        if (house != null)
        {
            // Check if the house is good or bad
            if (house.type == House.HouseType.Good)
            {
                audioSource.PlayOneShot(goodSound);

                GameManager.GetInstance().GivePointToSanta();
                GameManager.GetInstance().RemovePointFromGrinch();

            }
            else
            {
                audioSource.PlayOneShot(badSound);

                GameManager.GetInstance().RemovePointFromSanta();
                GameManager.GetInstance().GivePointToGrinch();

            }

            // Destroy the present
            Destroy(gameObject);
        }
    }
}
