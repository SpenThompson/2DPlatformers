using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D body;

    private float horizontal;
    public float runSpeed = 10f;
    public float jumpForce = 4000f;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("space") && !jumping)
        {
            body.AddForce(new Vector2(0, jumpForce));
            jumping = true;
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, body.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }
}
