using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] List<Transform> enemyList;
    public bool enemiesSpawned = false;
    public bool enemiesDefeated = false;
    public int waveNumber;

    void Update()
    {
        // Make sure that enemies of all types are destroyed before loading next wave from LoadWaves script.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] sinEnemies = GameObject.FindGameObjectsWithTag("SinEnemy");
        GameObject[] circleEnemies = GameObject.FindGameObjectsWithTag("CircleEnemy");
        if (enemies.Length == 0 && sinEnemies.Length == 0 && circleEnemies.Length == 0 && enemiesSpawned == true)
        {
            enemiesDefeated = true;
            return;
        }
    }

    // 3 seconds of break between waves 
    public void StartBattle()
    {
        enemiesDefeated = false;
        Invoke("SpawnEnemies", 3f);
    }

    // Spawn all enemies from the enemy list of current wave
    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            enemyList.Add(child);
            child.GetComponent<EnemyBehavior>().Spawn();
        }
        enemiesSpawned = true;
    }
}
