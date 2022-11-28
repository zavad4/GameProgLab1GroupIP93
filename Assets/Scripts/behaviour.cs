using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    bool isOnTheGround;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        isOnTheGround = true;
        movement = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            movement.x = speed * Input.GetAxis("Horizontal");
        }

        if (Input.GetAxis("Vertical") > 0 && isOnTheGround)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("ground"))
        {
            isOnTheGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            isOnTheGround = false;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = movement;
    }
}
