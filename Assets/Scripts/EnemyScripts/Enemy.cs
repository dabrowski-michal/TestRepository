using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, speed, enemyDamage;
    private PlayerStats playerTarget;
    public EnemySpawner enemySpawner;

    private bool slowed;

    private void Start()
    {
        playerTarget = FindObjectOfType<PlayerStats>();
        if(!enemySpawner) enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        MoveTowardsPlayer();
        CheckIfEnemyHitPlayer();
    }

    public void MoveTowardsPlayer()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, step);
        transform.LookAt(playerTarget.transform);
    }

    public void CheckIfEnemyHitPlayer()
    {
        if (Vector3.Distance(transform.position, playerTarget.transform.position) < 0.5f)
        {
            playerTarget.TakeDamage(enemyDamage);
            ReturnEnemyToObjectPool();
        }
    }

    public void CheckIfEnemyIsEliminated()
    {
        if(health <= 0)
        {
            ReturnEnemyToObjectPool();
        }
    }

    public void ReturnEnemyToObjectPool()
    {
        enemySpawner.DestroyEnemy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        CheckIfEnemyIsEliminated();
    }

    public void SlowDownEnemy(float effectTime)
    {
        if (!slowed) StartCoroutine(SlowingDown(effectTime));
    }

    IEnumerator SlowingDown(float effectTime)
    {
        slowed = true;
        speed = speed / 2;
        yield return new WaitForSeconds(effectTime);
        speed = speed * 2;
        slowed = false;
    }

}
