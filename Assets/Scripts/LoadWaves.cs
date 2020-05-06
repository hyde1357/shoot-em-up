using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // Add available waves to list
        // TODO get rid of the duplicate lists
        foreach (Transform child in transform)
        {
            waveList.Add(child);
            print("Wave added to list: " + child.GetComponent<BattleSystem>().waveNumber.ToString());
        }
        waves = waveList.ToArray();

    }
    
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
        // Spawn next wave of enemies, if any remaining
        currentWave += 1;
        print("Loading wave " + currentWave.ToString());
        if(currentWave >= 6)
        {
            Invoke("LoadMainMenu", 3f);
        }
        else
        {
            waveList[currentWave - 1].GetComponent<BattleSystem>().StartBattle();
        }
    }

    // Back to menu
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
