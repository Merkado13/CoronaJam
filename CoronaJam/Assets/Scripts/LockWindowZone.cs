using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWindowZone : MonoBehaviour, ITrigger
{
    public static readonly int MAX_WOODS = 3;
    private int currentNumWoods = 3;

    public void Exit(PlayerController player)
    {
        player.setCanLockWindow(false);
        Debug.Log("He salido de locking");
    }

    public void Enter(PlayerController player)
    {
        player.setCanLockWindow(true);
        Debug.Log("He entrado en locking");
    }

    public bool CanPerform(PlayerController player)
    {
        return currentNumWoods < MAX_WOODS;
    }

    public void Perform(PlayerController player)
    {
        currentNumWoods++;
        player.isLockingWindow = true;
    }
}
