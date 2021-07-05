using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private GameManager gameManager;
    public int health;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        health = gameManager.chosenDifficulty.playerHealth;
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        CheckIfPlayerIsBelowZero();
    }

    public void CheckIfPlayerIsBelowZero()
    {
        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }
}
