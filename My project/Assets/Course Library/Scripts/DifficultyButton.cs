using UnityEngine;
using UnityEngine.UI;


public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private Game_Manager game_Manager;   
    public int difficulty;
    public float spawnRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        game_Manager = GameObject.Find("Game Manager").GetComponent<Game_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
       
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
    }
}
