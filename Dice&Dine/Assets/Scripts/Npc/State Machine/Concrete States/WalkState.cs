using UnityEngine;

public class WalkState : State
{
    private int _index = 0;
    public WalkState(Customer customer, StateMachine stateMachine) : base(customer, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("WalkState");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        // if(!Input.GetKeyDown(KeyCode.Space)) return;
        // customer.transform.position = customer.targets.position;
        //ToTarget();
    }
    
}
