using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool gameOver;
    private int points;
    public float time;

    private EnemySpawner enemySpawnerScript;
    private PlayerStats playerScript;

    public Difficulty easy, medium, hard;
    public Difficulty chosenDifficulty;

    [SerializeField] 
    private Text pointsText, finalScoreText;
    [SerializeField] 
    private GameObject gameOverScreen;

    public void Awake()
    {
        gameOverScreen.SetActive(false);
        SetDifficultyLevel();
    }


    public void GameOver()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
        finalScoreText.text = points.ToString();

    }
    public void ScorePoint()
    {
        if (!gameOver)
        {
            points++;
            pointsText.text = points.ToString();
        }

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void SetDifficultyLevel()
    {
        switch (StateNameController.difficulty)
        {
            case "easy":
                chosenDifficulty = easy;
                break;
            case "medium":
                chosenDifficulty = medium;
                break;
            case "hard":
                chosenDifficulty = hard;
                break;
            default:
                chosenDifficulty = medium;
                break;
        }
    }

}
