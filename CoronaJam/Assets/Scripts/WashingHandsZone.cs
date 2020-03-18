using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingHandsZone : MonoBehaviour, ITrigger
{
    [SerializeField] private float cleanFactor = 0.5f;

    public void Exit(PlayerController player)
    {
        player.setCanWashHands(false);
        Debug.Log("He salido de washing");
    }

    public void Enter(PlayerController player)
    {
        player.setCanWashHands(true);
        Debug.Log("He entrado en washing");
    }

    public bool CanPerform(PlayerController player)
    {
        return player.getCleaness() < PlayerController.MAX_CLEAN;
    }

    public void Perform(PlayerController player)
    {
        //player.setCleaness(player.getCleaness() +cleanFactor);
        player.isWashingHands = true;
        Debug.Log("Me estoy lavando las manos");
    }
}
