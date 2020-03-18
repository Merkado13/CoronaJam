using AnimatorStateMachineUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        playerController.weapon.Show();
        Debug.Log("HEy");
    }

    [StateUpdateMethod("Player.Idle")]
    public void UpdateIdle()
    {
        playerController.Shoot();
        inputMovement.Movement();
        faceCursor.FaceToCursor();
        Debug.Log("HEy");
    }

    [StateExitMethod("Player.Idle")]
    public void ExitIdle()
    {
        playerController.weapon.Hide();
    }
}
