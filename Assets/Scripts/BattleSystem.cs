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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] sinEnemies = GameObject.FindGameObjectsWithTag("SinEnemy");
        GameObject[] circleEnemies = GameObject.FindGameObjectsWithTag("CircleEnemy");
        if (enemies.Length == 0 && sinEnemies.Length == 0 && circleEnemies.Length == 0 && enemiesSpawned == true)
        {
            enemiesDefeated = true;
            print("Enemies defeated. Waiting for next wave");
            return;
        }
    }

    public void StartBattle()
    {
        enemiesDefeated = false;
        //waveNumber = wave;
        Debug.Log("Start wave " + waveNumber.ToString());
        Invoke("SpawnEnemies", 3f);
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            enemyList.Add(child);
            child.GetComponent<EnemyBehavior>().Spawn();
            print("Enemy spawned");
        }
        enemiesSpawned = true;
    }
}
