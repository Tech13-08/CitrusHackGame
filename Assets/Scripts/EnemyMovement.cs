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
}
