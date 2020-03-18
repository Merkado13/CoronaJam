using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWashHands : MonoBehaviour, ITrigger
{
    public void deperform(PlayerController player)
    {
        player.setCanWashHands(false);
        Debug.Log("He salido de washing");
    }

    public void perform(PlayerController player)
    {
        player.setCanWashHands(true);
        Debug.Log("He entrado en washing");
    }
}
