using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWaves : MonoBehaviour
{
    [SerializeField] private List<Transform> waveList;
    [SerializeField] private Transform[] waves;

    [SerializeField] private int currentWave;
    private bool waveRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        print("Wave list loaded");
        currentWave = 0;

        foreach (Transform child in transform)
        {
            waveList.Add(child);
            print("Wave added to list: " + child.GetComponent<BattleSystem>().waveNumber.ToString());
            //child.GetComponent<BattleSystem>().Spawn();
        }
        waves = waveList.ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        if(waveRunning == false || waveList[currentWave - 1].GetComponent<BattleSystem>().enemiesDefeated == true)
        {
            waveRunning = true;
            NextWave();
        }
    }

    private void NextWave()
    {
        currentWave += 1;
        print("Loading wave " + currentWave.ToString());
        waveList[currentWave-1].GetComponent<BattleSystem>().StartBattle();
    }
}
