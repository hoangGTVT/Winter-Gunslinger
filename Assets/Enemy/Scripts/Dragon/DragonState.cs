using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonState : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;


    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject gameObject1 = GameObject.FindGameObjectWithTag("Player01Animation");
        if (gameObject1 != null)
        {
            player = gameObject1.transform;
        }
        else
        {
            return;
        }
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        animator.GetComponent<Dragon>().FindPlayer2();

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("IsAttack");
    }
}
