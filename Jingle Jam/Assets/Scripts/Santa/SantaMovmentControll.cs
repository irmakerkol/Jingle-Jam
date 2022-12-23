using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovmentControll : MonoBehaviour
{
    public int constantmovSpeed = 5;
    [SerializeField] private int speed = 8;
    private float horizontal;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Vertical");
        Face();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(constantmovSpeed, horizontal * speed);
    }

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
}
