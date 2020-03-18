using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger
{
    void Enter(PlayerController player);
    void Exit(PlayerController player);
    bool CanPerform(PlayerController player);
    void Perform(PlayerController player);
}
