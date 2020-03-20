using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{

    public static readonly float PLAYER_IDLE_FRONT = 0.0f;
    public static readonly float PLAYER_IDLE_BACK = 0.5f;
    public static readonly float PLAYER_IDLE_SIDE = 1.0f;
    public static readonly float PLAYER_WALKING_FRONT = 1.5f;
    public static readonly float PLAYER_WALKING_BACK = 2.0f;
    public static readonly float PLAYER_WALKING_SIDE = 2.5f;

    private Animator animator;
    private float idleRelated = PLAYER_IDLE_FRONT;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void ChangeAnimation(float animation)
    {
        animator.SetFloat("Blend", animation);
    }

    public void ChangeAnimationByInput(Vector2 input)
    {
        

        if (input.y < 0)
        {
            idleRelated = PLAYER_IDLE_FRONT;
            ChangeAnimation(PLAYER_WALKING_FRONT);

        }else if(input.y > 0)
        {
            idleRelated = PLAYER_IDLE_BACK;
            ChangeAnimation(PLAYER_WALKING_BACK);
        }

        if (input.x != 0)
        {
            idleRelated = PLAYER_IDLE_SIDE;
            ChangeAnimation(PLAYER_WALKING_SIDE);
        }

        
        if(input.x == 0 && input.y == 0)
        {
            ChangeAnimation(idleRelated);
        }


    }
}
