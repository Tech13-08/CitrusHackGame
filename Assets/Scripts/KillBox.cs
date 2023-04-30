using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    public LivesManager livesmanager;
    public GameManager gm;
    public Ground gr;

    void OnTriggerEnter2D(Collider2D other){
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        if (other.gameObject.layer == enemyLayer)
        {
            Destroy(other.gameObject);
        }

        int playerLayer = LayerMask.NameToLayer("Player");
        if (other.gameObject.layer == playerLayer)
        {
            livesmanager.lives -= 1;
            gm.gameRun = false;
        }

    }
}
