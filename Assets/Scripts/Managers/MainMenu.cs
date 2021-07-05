using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject difficultyPanel;


    public void Start()
    {
        difficultyPanel.SetActive(false);
    }

    public void NewGame()
    {
        difficultyPanel.SetActive(true);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void SetDifficulty(string input)
    {
        StateNameController.difficulty = input;
        StartNewGame();
    }

    public void StartNewGame()
    {
        #if UNITY_EDITOR
            SceneManager.LoadScene("Gameplay");
        #endif

        #if UNITY_STANDALONE
            Application.Quit();
        #endif
    }
}
