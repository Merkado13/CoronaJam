
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class IdlePlayerState : MonoBehaviour
{

    private PlayerController playerController;
    private InputMovement2D inputMovement;
    private Animator animator;
    private FacingCursor faceCursor;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        inputMovement = GetComponent<InputMovement2D>();
        animator = GetComponent<Animator>();
        faceCursor = GetComponent<FacingCursor>();
    }

    [StateEnterMethod("Player.Idle")]
    public void StartIdle()
    {
        playerController.currentWeapon.Show();
    }

    [StateUpdateMethod("Player.Idle")]
    public void UpdateIdle()
    {
        //Behaviour
        playerController.ChangeBtwWeapons();
        playerController.Shoot();
        playerController.PerformInZone();
        inputMovement.Movement();
        faceCursor.FaceToCursor();

        //transitions
        if (playerController.isWashingHands)
        {
            inputMovement.Stop();
            animator.SetBool("isWashingHands", true);
        }

        if (playerController.isLockingWindow)
        {
            inputMovement.Stop();
            animator.SetBool("isLockingWindow", true);
        }

        if (playerController.isCrafting)
        {
            inputMovement.Stop();
            animator.SetBool("isCrafting", true);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            playerController.setCleaness(0);
        }

        if (playerController.isDead())
        {
            animator.SetBool("isDead", true);
        }
    }

    [StateExitMethod("Player.Idle")]
    public void ExitIdle()
    {
        playerController.currentWeapon.Hide();
    }
    
}
