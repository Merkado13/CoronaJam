using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class DeadPlayerState : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [StateEnterMethod("Player.Dead")]
    public void StartDead()
    {

    }

    [StateUpdateMethod("Player.Dead")]
    public void UpdateDead()
    {
        Debug.Log("Me estoy lavando las manos");
    }

    [StateExitMethod("Player.Dead")]
    public void ExitDead()
    {

    }
}
