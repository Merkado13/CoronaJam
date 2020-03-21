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
    [SerializeField] private GameObject gear;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject liquidSoap;
    [SerializeField] private GameObject bluePill;
    [SerializeField] private GameObject redPill;

    #endregion variables

    public void SpawnEnemy(float multiplier)
    {
        GameObject enemyClone = Instantiate(enemy, transform.position, transform.rotation);

        Enemy_FSM enemyFSM = enemyClone.GetComponent<Enemy_FSM>();
        enemyFSM.WindowsOutside = windowsOutside;
        enemyFSM.WindowsInside = windowsInside;
        enemyFSM.PathfindingConfig = pathfindingConfig;
        enemyFSM.ToiletPaper = toiletPaper;

        EnemyHealth enemyHealth = enemyClone.GetComponent<EnemyHealth>();
        enemyHealth.RoundController = roundController;
        enemyHealth.Gear = gear;
        enemyHealth.Ammo = ammo;
        enemyHealth.LiquidSoap = liquidSoap;
        enemyHealth.BluePill = bluePill;
        enemyHealth.RedPill = redPill;
        enemyHealth.MultiplyHealth(multiplier);
    }
}