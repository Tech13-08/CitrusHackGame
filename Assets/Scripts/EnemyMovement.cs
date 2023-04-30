using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameManager gm;
    private Rigidbody2D enemyRigidbody => GetComponent<Rigidbody2D>();

    private void FixedUpdate(){
        if(!gm.gameRun){
            enemyRigidbody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int playerLayer = LayerMask.NameToLayer("PLayer");
        if (collision.gameObject.layer == playerLayer)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>());
        }
    }
}
