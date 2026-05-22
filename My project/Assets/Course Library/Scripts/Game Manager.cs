using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Game_Manager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public TextMeshProUGUI livesText;
    public int lives;
    public GameObject pauseScreen;
    private bool paused;
    public GameObject titleScreen;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void UpdateLives(int livesToChange)
    {
        lives += livesToChange;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
        
    } 
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }       
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void StartGame()
    {
        
        score = 0;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);
    }
    void ChangePaused()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.CompareTag("Player") && isGameActive)
        {

            UpdateLives(-1);
        }
    } 
}
