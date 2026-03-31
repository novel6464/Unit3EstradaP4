using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;
    private PlayerController PlayerControllerScript;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        PlayerControllerScript.gameOver = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControllerScript.gameOver)
        {
            if(PlayerControllerScript.doubleSpeed)
            {
                score +=  2; // Double the score increment when double speed is active
            }
            else
            {
                score++; // Normal score increment
            }

           Debug.Log("Score: " + score);
        }
    }
    
    
}
