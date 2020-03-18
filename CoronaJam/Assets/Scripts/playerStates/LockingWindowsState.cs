using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class LockingWindowsState : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [StateEnterMethod("Player.LockingWindow")]
    public void StartLockingWindow()
    {

    }

    [StateUpdateMethod("Player.LockingWindow")]
    public void UpdateLockingWindow()
    {
        Debug.Log("Me estoy LockingWindow");
    }

    [StateExitMethod("Player.ILockingWindow")]
    public void ExitLockingWindow()
    {

    }
}
