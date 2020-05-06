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
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (gameObjects.Length == 0 && enemiesSpawned == true)
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
