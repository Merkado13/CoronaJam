using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger
{
    void perform(PlayerController player);
    void deperform(PlayerController player);
}
