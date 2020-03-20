using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region variables

    [SerializeField] private SAP2D.SAP2DPathfindingConfig pathfindingConfig;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] windowsOutside;
    [SerializeField] private Transform[] windowsInside;
    [SerializeField] private GameObject toiletPaper;
    [SerializeField] private RoundController roundController;

    #endregion variables

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void SpawnEnemy()
    {
        GameObject enemyClone = Instantiate(enemy, transform.position, transform.rotation);

        Enemy_FSM enemyFSM = enemyClone.GetComponent<Enemy_FSM>();
        enemyFSM.WindowsOutside = windowsOutside;
        enemyFSM.WindowsInside = windowsInside;
        enemyFSM.PathfindingConfig = pathfindingConfig;
        enemyFSM.ToiletPaper = toiletPaper;

        EnemyHealth enemyHealth = enemyClone.GetComponent<EnemyHealth>();
        enemyHealth.RoundController = roundController;
    }
}