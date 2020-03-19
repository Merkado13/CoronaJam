using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class LockingWindowsState : MonoBehaviour
{

    private Animator animator;
    private PlayerController player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
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
        player.PerformInZone();
        Debug.Log("Estoy loquenado");

        //transitions
        if (player.isDead()) {

            animator.SetBool("isDead", true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            player.isLockingWindow = false;
            animator.SetBool("isLockingWindow", player.isLockingWindow);
        }
    }

    [StateExitMethod("Player.ILockingWindow")]
    public void ExitLockingWindow()
    {
        player.isLockingWindow = false;
    }
}
