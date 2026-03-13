
using UnityEngine;

public class LeaveState : State
{
    protected LeaveState(Customer customer, StateMachine stateMachine) : base(customer, stateMachine)
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("LeaveState");
        customer.GetComponent<Component>().gameObject.SetActive(false);
    }
    
}
