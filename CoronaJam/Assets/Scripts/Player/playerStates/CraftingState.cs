using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class CraftingState : MonoBehaviour
{

    private Animator animator;
    private PlayerController player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
    }

    [StateUpdateMethod("Player.Crafting")]
    public void UpdateCrafting()
    {

        if (!player.isCrafting)
        {
            animator.SetBool("isCrafting", false);
        }

        if (player.isDead())
        {
            animator.SetBool("isDead", true);
        }
    }

}
