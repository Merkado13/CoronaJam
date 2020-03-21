using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class CraftingState : MonoBehaviour
{
    [SerializeField] private AudioClip craftingClip;

    private Animator animator;
    private PlayerController player;
    private AudioSource playerSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerSound = GetComponent<AudioSource>();
    }

    [StateEnterMethod("Player.Crafting")]
    public void EnterCraftingState()
    {
        playerSound.clip = craftingClip;
        playerSound.Play();
    }

    [StateUpdateMethod("Player.Crafting")]
    public void UpdateCrafting()
    {
        if(!player.isCrafting) {
            animator.SetBool("isCrafting", false);
        }

        if(player.isDead()) {
            animator.SetBool("isDead", true);
        }
    }
}