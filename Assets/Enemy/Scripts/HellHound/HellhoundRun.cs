using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class HellhoundRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 3f;
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
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 taget = new Vector2(player.position.x, player.position.y);
        Vector2 newPos= Vector2.MoveTowards(rb.position, taget, speed* Time.deltaTime);
        newPos.y = rb.position.y;
        rb.MovePosition(newPos);
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
