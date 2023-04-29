using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int playerLayer = LayerMask.NameToLayer("PLayer");
        if (collision.gameObject.layer == playerLayer)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>());
        }
    }
}
