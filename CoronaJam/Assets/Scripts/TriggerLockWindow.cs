using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLockWindow : MonoBehaviour, ITrigger
{
    public void deperform(PlayerController player)
    {
        player.setCanLockWindow(false);
        Debug.Log("He salido de locking");
    }

    public void perform(PlayerController player)
    {
        player.setCanLockWindow(true);
        Debug.Log("He entrado en locking");
    }

}
