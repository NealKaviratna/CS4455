using UnityEngine;
using System.Collections;

public class slideforward : StateMachineBehaviour {

	private CharacterController cc;
	private float timer = 0.0f;
	private Vector3 inputDir;

	 //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.timer = 3.0f;
		cc = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CharacterController>();
		this.inputDir = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
	}

	 //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		timer -= Time.deltaTime;
		Debug.Log(timer);
		if (this.timer < 0) {
			inputDir.x = Input.GetAxis ("Horizontal");
			inputDir.y = Input.GetAxis ("Vertical");
			this.cc.SimpleMove(inputDir);
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
