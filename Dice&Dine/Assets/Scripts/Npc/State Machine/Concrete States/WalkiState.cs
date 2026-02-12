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
        customer.transform.position = Vector2.MoveTowards(customer.transform.position, customer.targets[_index].position, customer.MoveSpeed * Time.deltaTime);
        ReachedTarget();
        
        if(!Input.GetKeyDown(KeyCode.Space)) return;
        ToTarget();
    }

    private void ReachedTarget()
    {
        var dir = (customer.transform.position - customer.targets[_index].position).magnitude;
        if (dir < 0.1f)
        {
            customer.StateMachine.ChangeState(customer.WaitState);
        }
    }
    
    
    private void ToTarget()
    {
        _index += 1;
        Debug.Log("WalkState");
        if (_index > customer.targets.Count -1)
            _index = 0;
    }
}
