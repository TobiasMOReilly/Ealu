using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distracted_Behavior : StateMachineBehaviour {

    private Distractable distract;
    private MoveToPoint moveToPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distract = animator.gameObject.GetComponent<Distractable>();
        moveToPoint = animator.gameObject.GetComponent<MoveToPoint>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (distract.SliotorPosition() != null)
        {
            moveToPoint.MoveTo(distract.SliotorPosition());
            Debug.Log("GOING TO SLIOTOR");
        }

        Debug.Log(Vector3.Distance(animator.gameObject.transform.position, distract.SliotorPosition()));

        if ( Vector3.Distance(animator.gameObject.transform.position, distract.SliotorPosition()) < 1)
        {
            animator.SetBool("AtSliotorPosition", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Distracted", false);
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
