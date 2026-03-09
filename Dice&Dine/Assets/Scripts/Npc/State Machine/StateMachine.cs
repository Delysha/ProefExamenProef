public class StateMachine
{   
    public State CurrentState { get; set; }

    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        CurrentState.EnterState();
    }

    public void ChangeState(State newState)
    {
        CurrentState.EnterState();
        CurrentState = newState;
        CurrentState.EnterState();
    }
}
