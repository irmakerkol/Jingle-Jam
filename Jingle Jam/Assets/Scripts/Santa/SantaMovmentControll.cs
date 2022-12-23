using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovmentControll : MonoBehaviour
{
    public int constantmovSpeed = 5;
    [SerializeField] private int speed = 8;
    private float horizontal;
<<<<<<< Updated upstream
    private bool isFacingRight = true;

=======
    public Animator animator;
    public bool isPressed;
>>>>>>> Stashed changes
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Vertical");
<<<<<<< Updated upstream
        Face();
=======
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(WaitAnimation());
        }
        
>>>>>>> Stashed changes
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(constantmovSpeed, horizontal * speed);
    }

<<<<<<< Updated upstream
    private void Face()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale *= -1;
            transform.localScale = localScale;
        }
    }
=======
    IEnumerator WaitAnimation()
    {
        animator.SetBool("isPressed", true);

        yield return new WaitForSeconds(0.4f);

        //After we have waited 5 seconds print the time again.
        animator.SetBool("isPressed", false);

    }

>>>>>>> Stashed changes
}
