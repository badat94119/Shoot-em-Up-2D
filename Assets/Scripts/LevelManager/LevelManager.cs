using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;

    public GameObject deathScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public int score;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }    
    }

    [HideInInspector] public bool isGameStarted;
   
    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
    }

    public void GameOver()
    {
        deathScreen.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
    }
    
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
