using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    public float MeltSpeed = -0.08f;

    public GameManager gm;

    public float raiseIceTime = 0f;  
    [SerializeField] Transform leftBorder;
    public Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private BoxCollider2D leftBorderCollider => leftBorder.GetComponent<BoxCollider2D>();

    void Update(){
        if(gm.gameRun){
            rb.velocity = new Vector2(rb.velocity.x, MeltSpeed);
            if(transform.position.y < -4.75){
                if(raiseIceTime > 0){
                    MeltSpeed += 0.001f;
                    raiseIceTime -= Time.deltaTime;
                }
                else if(MeltSpeed > 0){
                    MeltSpeed = -0.05f;
                }
            }
            else{
                MeltSpeed = -0.05f;
                raiseIceTime = 0f;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D asdf){
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        if (asdf.gameObject.layer == enemyLayer)
        {
            MeltSpeed -= 0.01f;
            Destroy(asdf.gameObject);
        }
    }
}
