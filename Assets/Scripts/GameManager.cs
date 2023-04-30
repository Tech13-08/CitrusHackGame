using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameRun = true;

    public float speed = 1f;

    public float increase = 1f;

    private float lastTimeChecked = 0f;

    public void FixedUpdate(){
        if ((Time.time - lastTimeChecked) % increase == 0 && speed < 10){
            speed += 0.07f * increase;
            increase += 1;
            lastTimeChecked = Time.time;
        }
        
    }
}
