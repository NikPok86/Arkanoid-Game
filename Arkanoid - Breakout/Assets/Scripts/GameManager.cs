using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public int lives;
    public Text scoreText;
    public Text livesText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;   
        numberOfBricks = GameObject.FindGameObjectsWithTag ("brick").Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives (int changeInLives)
    {
        lives += changeInLives;

        if (lives <=0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore (int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive (true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene ("Arkanoid"); 
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log ("Game Quit");
    }

}
