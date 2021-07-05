using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private GameObject enemyPrefab;

    private GameManager gameManager;
    private ObjectPool objectPool;

    private float enemySpawnRate;
    private int enemyHealth;


    public void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        gameManager = FindObjectOfType<GameManager>();
        enemySpawnRate = gameManager.chosenDifficulty.enemySpawnRate;
        enemyHealth = gameManager.chosenDifficulty.enemyHealth;

        StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        yield return new WaitForSeconds(enemySpawnRate);
        SpawnEnemy();
        StartCoroutine(SpawningEnemies());
    }

    public void SpawnEnemy()
    {
        Vector3 position = RandomCirclePosition(radius);
        GameObject newEnemy = objectPool.GetObjectFromPool(enemyPrefab);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        enemyScript.GetComponent<Enemy>().enemySpawner = this;
        enemyScript.health = enemyHealth;
        newEnemy.transform.localPosition = position;
        RandomizeEnemyColor(newEnemy);
    }

    Vector3 RandomCirclePosition (float radius)
    {
        float angle = Random.Range(0,360) * Mathf.PI / 180;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        Vector3 randomPosition = new Vector3(x, 0, z);

        return randomPosition;
    }

    public void RandomizeEnemyColor(GameObject enemy)
    {
        enemy.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.6f, 0.6f, 0.6f, 0.6f);
    }

    public void DestroyEnemy(GameObject enemyPrefab)
    {
        objectPool.ReturnObjectBackToPool(enemyPrefab);
        gameManager.ScorePoint();
    }
}
