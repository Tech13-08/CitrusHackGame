using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public PlayerMovement player;

    public TextMeshProUGUI score;

    public void Update(){
        score.text = ""+Mathf.RoundToInt(player.lm.score);
    }

    public void ToggleValue(){

        Transform playerTransform = player.GetComponent<Transform>();
        playerTransform.position = new Vector3(-3.905f,-2.09f,0);
        player.lm.score = 0;
        player.lm.lives = 3;
        player.lm.leaves = 0;
        gm.speed = 1f;

    gm.increase = 1f;

    gm.lastTimeChecked = 0f;
        Transform grTransform = player.gr.GetComponent<Transform>();
        grTransform.position = new Vector3(0.447f, -4.876f,0);

        gm.gameRun = !gm.gameRun;
        transform.position = transform.position - new Vector3(1000,0,0);
    }
}
