using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;

    public void ToggleValue(){
        gm.gameRun = !gm.gameRun;
        transform.position = transform.position - new Vector3(1000,0,0);
    }
}
