using UnityEngine;

public class IdleState : State
{
    public IdleState(Customer customer, StateMachine stateMachine) : base(customer, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("IdleState");
    }

    private void Deactivate()
    {
        
    }
}
