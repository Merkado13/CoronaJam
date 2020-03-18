using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region variables

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] windows;

    #endregion variables

    // Start is called before the first frame update
    private void Start()
    {
        GameObject enemyClone = Instantiate(enemy);
        enemyClone.GetComponent<Enemy_FSM>().Windows = windows;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}