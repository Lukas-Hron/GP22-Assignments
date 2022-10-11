using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Vector2 moveVel = new Vector2();

    private Rigidbody2D rb2d;

    public float jumpPower = 10;
    public bool grounded;
    bool isJump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 1;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump")) //Jump next time grounded is true
        isJump = true;

    }

    void FixedUpdate()
    {
        moveVel.x = Input.GetAxis("Horizontal") * speed; 

        if (isJump && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = false;
        }

        moveVel.y = rb2d.velocity.y; //Always keep y velocity

        rb2d.velocity = moveVel;
    }

}