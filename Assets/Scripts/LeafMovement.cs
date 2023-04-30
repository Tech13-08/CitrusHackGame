using UnityEngine;

public class LeafMovement : MonoBehaviour
{
    public GameManager gm;
    private Rigidbody2D leafRigidbody => GetComponent<Rigidbody2D>();

    private void FixedUpdate(){
        if(!gm.gameRun){
            leafRigidbody.velocity = Vector2.zero;
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     int playerLayer = LayerMask.NameToLayer("Player");
    //     if (collision.gameObject.layer == playerLayer)
    //     {
    //         Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>());
    //     }
    // }
}
