using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LivesManager lm;
    public GameManager gm;

    public Ground gr;
    public Animator animator;

    private SpriteRenderer sr => GetComponent<SpriteRenderer>();

    // Start is called before the first frame update
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    [SerializeField] private Transform enemyHit;

    private BoxCollider2D enemyHitCollider => enemyHit.GetComponent<BoxCollider2D>();
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 9f;
    private float jumpStartTime;
    private bool startJump = false;

    private bool isGrounded = false;

    [SerializeField] float scrollSpeed = 1f;

    private float damagedStartTime;
    private bool damaged = false;

    public Color damagedRed;

    public float knockbackDistance = 1.0f;

    bool canCollide = true;
    float cooldownDuration = 0.5f;
    float cooldownTimer = 0f;

    private void Update(){
        if(gm.gameRun){
            if (Input.GetButtonDown("Jump") && isGrounded)
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
            animator.SetBool("jump", !isGrounded);
            if (!canCollide)
            {
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0f)
                {
                    canCollide = true;
                }
            }
        }
        }

    private void FixedUpdate(){
        if(gm.gameRun){
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 playerVelocity = new Vector2((horizontalInput * speed) - scrollSpeed, rb.velocity.y);
            rb.velocity = playerVelocity;
            animator.SetFloat("speed", horizontalInput);
        }
        else{
            animator.SetFloat("speed", 0f);
        }

        if(lm.lives == 0){
            gm.gameRun = false;
            animator.SetBool("dead", true);
            rb.velocity = Vector3.zero;
        }
        if(damaged && (Time.time - damagedStartTime >= 0.2f)){
            damaged = false;
            sr.color = Color.white;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int groundLayer = LayerMask.NameToLayer("Ground");
        if (other.gameObject.layer == groundLayer)
        {
            isGrounded = true;
        }

        int enemyLayer = LayerMask.NameToLayer("Enemy");
        if (other.gameObject.layer == enemyLayer && canCollide)
        {
            lm.lives -= 1;
            sr.color = damagedRed;
            damaged = true;
            damagedStartTime = Time.time;
            Vector3 knockbackDirection = transform.position - other.transform.position;

            // Normalize the direction vector and multiply by a force value
            knockbackDirection.Normalize();
            
            
            // Move the player back along the knockback direction
            transform.position += knockbackDirection * knockbackDistance;
            canCollide = false;
            cooldownTimer = cooldownDuration;
        }

        int leafLayer = LayerMask.NameToLayer("Leaf");
        if (other.gameObject.layer == leafLayer)
        {
            lm.leaves += 1;
            Destroy(other.gameObject);

            gr.raiseIceTime += 2f;
            
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

    void OnTriggerEnter2D(Collider2D other){
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        if (other.gameObject.layer == enemyLayer)
        {
            lm.score += 100;
            lm.info.text += "\n+100";
            Destroy(other.gameObject);
        }

        int leafLayer = LayerMask.NameToLayer("Leaf");
        if (other.gameObject.layer == leafLayer)
        {
            lm.leaves += 1;
            Destroy(other.gameObject);

            gr.raiseIceTime += 2f;
        }
    }

}
