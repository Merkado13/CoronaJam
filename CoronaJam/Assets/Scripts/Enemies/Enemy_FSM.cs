using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class Enemy_FSM : MonoBehaviour
{
    #region variables

    public Transform[] WindowsOutside { get; set; }
    public Transform[] WindowsInside { get; set; }
    public SAP2D.SAP2DPathfindingConfig PathfindingConfig { get; set; }
    public GameObject ToiletPaper { get; set; }

    [SerializeField] private float timeToBreakWindow;

    private SAP2D.SAP2DAgent navAgent;
    private Animator enemyFSM;
    private Window targetWindow;

    #endregion variables

    // Start is called before the first frame update
    private void Start()
    {
        navAgent = GetComponent<SAP2D.SAP2DAgent>();
        enemyFSM = GetComponent<Animator>();

        navAgent.Config = PathfindingConfig;
    }

    #region StateMachine

    [StateEnterMethod("Base.Search window")]
    public void EnterSearchWindow()
    {
        enemyFSM.ResetTrigger("KnockFromWindow");
        SearchWindow(WindowsOutside);
    }

    public void SearchWindow(Transform[] windows)
    {
        float actualDistance = 100000f;

        foreach(Transform windowPos in windows) {
            float calculatedDistance = Vector2.Distance(transform.position, windowPos.position);
            if(calculatedDistance < actualDistance) {
                navAgent.Target = windowPos;
                actualDistance = calculatedDistance;
            }
        }
    }

    [StateEnterMethod("Base.Break window")]
    public void EnterBreakWindow()
    {
        InvokeRepeating("BreakWindow", timeToBreakWindow, timeToBreakWindow);
    }

    private void BreakWindow()
    {
        if(targetWindow.Barricades > 0) {
            targetWindow.Barricades--;
            targetWindow.UpdateSprite();
        }
        else {
            CancelInvoke("BreakWindow");
            enemyFSM.SetTrigger("WindowBroken");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Window>() != null) {
            enemyFSM.SetTrigger("GetToWindow");
            enemyFSM.SetTrigger("RunAway");
            targetWindow = collision.GetComponent<Window>();
        }

        if(collision.GetComponent<ToiletPaper>() != null) {
            collision.transform.parent = transform;
            collision.transform.localPosition = Vector3.zero;
            enemyFSM.SetTrigger("GetToWindowExit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Window>() != null) {
            enemyFSM.ResetTrigger("GetToWindow");
            enemyFSM.SetTrigger("KnockFromWindow");

            CancelInvoke("BreakWindow");
        }
    }

    [StateEnterMethod("Base.Go for toilet paper")]
    public void EnterToiletPaper()
    {
        enemyFSM.ResetTrigger("GetToWindow");
        enemyFSM.ResetTrigger("RunAway");
        navAgent.Target = ToiletPaper.transform;
    }

    [StateEnterMethod("Base.Search window exit")]
    public void EnterSearchWindowExit()
    {
        SearchWindow(WindowsInside);
    }

    [StateEnterMethod("Base.Run away")]
    public void EnterRunAway()
    {
        if(targetWindow.Barricades > 0) {
            InvokeRepeating("BreakWindow", timeToBreakWindow, timeToBreakWindow);
        }
    }

    [StateUpdateMethod("Base.Run away")]
    public void UpdateRunAway()
    {
        if(targetWindow.Barricades == 0) {
            navAgent.Target = targetWindow.transform.GetChild(0).transform;
            //TODO: hacer que pierda el jugador
        }
    }

    #endregion StateMachine
}