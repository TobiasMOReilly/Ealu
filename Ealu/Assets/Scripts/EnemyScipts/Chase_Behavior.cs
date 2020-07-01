using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase_Behavior : StateMachineBehaviour {

    private MoveToPoint moveToPoint;
    private FieldOfView fOV;
    private Animator anim;
    private EnemyAI enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveToPoint = animator.gameObject.GetComponent<MoveToPoint>();
        fOV = animator.gameObject.GetComponent<FieldOfView>();
        enemy = animator.gameObject.GetComponent<EnemyAI>();
        anim = animator;
        //Raise playerSpottedEvent (triggers music change)
        anim.gameObject.GetComponent<EnemyAI>().RaiseSpottedEvent();
        //Increase speed
        anim.gameObject.GetComponent<NavMeshAgent>().speed = 8;
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        moveToPoint.MoveTo(enemy.GetLastKnownPosition());
    
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        anim.SetBool("PlayerSpotted", false);
        anim.gameObject.GetComponent<NavMeshAgent>().speed = 6;
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
