using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunForward : EnemyStateMachine
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //  GetEnemy(animator).Flip();
        GetEnemy(animator).SpawnBomb();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetEnemy(animator).SetVelocity(GetEnemy(animator).data.runSpeed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // GetEnemy(animator).Flip();

    }
}