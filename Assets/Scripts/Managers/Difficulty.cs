using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Difficulty", menuName = "Difficulty")]
public class Difficulty : ScriptableObject
{

    public int playerHealth, enemyHealth;
    public float enemySpawnRate;

}
