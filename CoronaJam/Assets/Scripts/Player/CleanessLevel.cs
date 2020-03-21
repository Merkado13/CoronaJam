using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanessLevel : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private float cleanessDownFactor = 1;
    [SerializeField] private bool isDebug = false;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!isDebug)
            player.setCleaness(player.getCleaness() - cleanessDownFactor * Time.deltaTime);
    }
}
