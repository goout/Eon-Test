using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttackBehaviour : StateMachineBehaviour {


    //	OnStateMachineEnter is called when entering a statemachine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash) {
        int test = Random.Range(0, 2);
        Debug.Log(test);
        animator.SetInteger("AttackIndex", test);

    }

}
