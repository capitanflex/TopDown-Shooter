using UnityEngine;

public class AttackID : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("AttackID", Random.Range(0,5));
    }
}
