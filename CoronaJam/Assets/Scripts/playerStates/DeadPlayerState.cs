using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AnimatorStateMachineUtil;

public class DeadPlayerState : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    [StateEnterMethod("Player.Dead")]
    public void StartDead()
    {
        //la animación se iniará en el animator
        SceneManager.LoadScene((int)SceneOrder.Scenes.GAME_OVER);
    }

    [StateUpdateMethod("Player.Dead")]
    public void UpdateDead()
    {
        //cuando termine la animación pasar a la escena
    }

    [StateExitMethod("Player.Dead")]
    public void ExitDead()
    {
        //probar que al acabar la animación con una transición con exit a un estado vacio la escena
        //game over se carge sin retardo
    }
}
