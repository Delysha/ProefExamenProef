public class State
{
    protected Customer customer;
    protected StateMachine stateMachine;

    protected State(Customer customer, StateMachine stateMachine)
    {
        this.customer = customer;
        this.stateMachine = stateMachine;
    }
    
    public virtual void EnterState(){}
    public virtual void ExitState() {}
    public virtual void FrameUpdate() {}
    
}

