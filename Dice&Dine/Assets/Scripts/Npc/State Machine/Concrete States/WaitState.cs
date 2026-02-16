using UnityEngine;

public class WaitState : State
{
    public WaitState(Customer customer, StateMachine stateMachine) : base(customer, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("WaitState Mph....");
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
