using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovmentControll : MonoBehaviour
{
    public int constantmovSpeed = 5;
    [SerializeField] private int speed = 8;
    private float horizontal;
    public Animator animator;
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(WaitForSantaAnim());
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(constantmovSpeed, horizontal * speed);
    }
    IEnumerator WaitForSantaAnim()
    {
        animator.SetBool("isPressed", true);

        yield return new WaitForSeconds(0.4f);

        animator.SetBool("isPressed", false);

    }
}
