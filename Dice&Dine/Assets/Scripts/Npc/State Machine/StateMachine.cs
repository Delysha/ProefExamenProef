public class StateMachine
{   
    public State currentState { get; set; }

    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.EnterState();
    }

    public void ChangeState(State newState)
    {
        currentState.EnterState();
        currentState = newState;
        currentState.EnterState();
    }
}
