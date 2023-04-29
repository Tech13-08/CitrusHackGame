using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private float jumpStartTime;
    private bool startJump = false;

    private bool isGrounded = false;

    private void Update(){
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f && isGrounded)
            {
                jumpStartTime = Time.time;
                startJump = true;
            }
        if (Input.GetButtonUp("Jump") || (Time.time - jumpStartTime) > 0.6f){
            jumpStartTime = 0f;
            startJump = false;
        }
        if (startJump){
            float newVelY = jumpForce * (0.5f* (Time.time - jumpStartTime));
            if (rb.velocity.y <= jumpForce){
                rb.AddForce(new Vector2(0f, newVelY), ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate(){
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int groundLayer = LayerMask.NameToLayer("Ground");
        if (other.gameObject.layer == groundLayer)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        int groundLayer = LayerMask.NameToLayer("Ground");
        if (other.gameObject.layer == groundLayer)
        {
            isGrounded = false;
        }
    }

}