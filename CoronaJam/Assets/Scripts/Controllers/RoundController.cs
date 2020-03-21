using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    #region variables

    [SerializeField] private EnemySpawner[] enemySpawners;
    [SerializeField] private Text roundText;
    [SerializeField] private int addEnemiesPerRound;
    [SerializeField] private float healthMultiplier;
    [SerializeField] private float timeBetweenRounds;
    [SerializeField] private AudioSource sceneAudio;
    [SerializeField] private AudioClip betweenRoudsClip;
    [SerializeField] private AudioClip duringRoundClip;

    private int round;
    private int enemiesSpawnedInRound;
    private int enemyNumberPerRound;
    private int enemiesKilledInRound;

    #endregion variables

    // Start is called before the first frame update
    private void Start()
    {
        round = 1;
        enemiesSpawnedInRound = 0;
        enemiesKilledInRound = 0;
        enemyNumberPerRound = 6; //6

        UpdateRoundText();
        InvokeRepeating("SpawnEnemies", timeBetweenRounds, 3);
    }

    private void SpawnEnemies()
    {
        if(sceneAudio.clip != duringRoundClip) {
            sceneAudio.clip = duringRoundClip;
            sceneAudio.Play();
        }

        for(int i = 0; i < 3; i++) { //3
            enemiesSpawnedInRound++;
            EnemySpawner randomSpawn = enemySpawners[Random.Range(0, enemySpawners.Length)];
            randomSpawn.SpawnEnemy(Mathf.Pow(healthMultiplier, round));
        }

        if(enemiesSpawnedInRound >= enemyNumberPerRound) {
            CancelInvoke("SpawnEnemies");
        }
    }

    public void EnemyKilled()
    {
        enemiesKilledInRound++;

        if(enemiesKilledInRound >= enemyNumberPerRound) {
            NextRound();
        }
    }

    private void NextRound()
    {
        round++;
        enemiesKilledInRound = 0;
        enemiesSpawnedInRound = 0;
        enemyNumberPerRound += addEnemiesPerRound;
        sceneAudio.clip = betweenRoudsClip;
        sceneAudio.Play();
        UpdateRoundText();
        InvokeRepeating("SpawnEnemies", timeBetweenRounds, 2);
    }

    private void UpdateRoundText()
    {
        roundText.text = round.ToString();
    }
}