using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class WashingHandsState : MonoBehaviour
{
    [SerializeField] private AudioClip whasingHandsClip;

    private Animator animator;
    private PlayerController player;
    private AudioSource playerSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerSound = GetComponent<AudioSource>();
    }

    [StateEnterMethod("Player.WashingHands")]
    public void EnterWhashingState()
    {
        playerSound.clip = whasingHandsClip;
        playerSound.Play();
    }

    [StateUpdateMethod("Player.WashingHands")]
    public void UpdateWashingHands()
    {
        player.PerformInZone();
        Debug.Log("me estoy lavando las manos");

        //transitions

        if(player.isDead()) {
            animator.SetBool("isDead", true);
        }
        else if(Input.GetKeyUp(KeyCode.E)) {
            player.isWashingHands = false;
        }

        animator.SetBool("isWashingHands", player.isWashingHands);
    }

    [StateExitMethod("Player.WashingHands")]
    public void ExitWashingHands()
    {
        player.isWashingHands = false;
    }
}