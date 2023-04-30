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
}
