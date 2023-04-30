using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] float ScrollSpeed = 1f;
    [SerializeField] float offset;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        gm.gameRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameRun){
            offset = offset + (Time.deltaTime * (ScrollSpeed*gm.speed)) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
