using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Behavior : StateMachineBehaviour {

    private MoveToPoint moveToPoint;
    private PatrolV2 patrol;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveToPoint = animator.gameObject.GetComponent<MoveToPoint>();
        patrol = animator.gameObject.GetComponent<PatrolV2>();
        animator.gameObject.GetComponent<EnemyAI>().RaisePatrolEvent();
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    
        //if enemy at their destination, move to next destination
        if(patrol.AtDestination())
        {
            moveToPoint.MoveTo(patrol.GetDestination());
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
