using System.Collections;
using UnityEngine;

public class Santa : MonoBehaviour
{
    public float speed = 10.0f; // The speed at which Santa moves
    public float tilt = 4.0f; // The tilt of the Santa sprite when he moves
    public float yMin, yMax; // The boundaries of the screen
    public GameObject presentPrefab; // The prefab for the present that Santa drops
    [SerializeField] Rigidbody2D rigidbody; // The Rigidbody2D component for Santa

    public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropPresent();
            StartCoroutine(WaitForSantaAnim());
        }
    }

    private void DropPresent()
    {
        // Create a new present object
        GameObject presentObject = Instantiate(presentPrefab, transform.position, Quaternion.identity);

    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");

        // Set the velocity of Santa based on the input axes
        Vector2 movement = new Vector2(0.5f, moveVertical);
        rigidbody.velocity = movement * speed;

        // Clamp Santa's position to the boundaries of the screen
        rigidbody.position=  new Vector2(rigidbody.position.x, Mathf.Clamp(rigidbody.position.y, yMin, yMax));

    }

    IEnumerator WaitForSantaAnim()
    {
        animator.SetBool("isPressed", true);

        yield return new WaitForSeconds(0.15f);

        animator.SetBool("isPressed", false);

    }
}
