using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, IWalkable, IWaitable
{
    public StateMachine StateMachine { get; private set; }
    public EatingState EatingState { get; private set; }
    public WaitState WaitState { get; private set; }
    public WalkState WalkState { get; private set; }
    public IdleState IdleState { get; private set; }
    
    public int money;
    public int patience;
    public List<Transform> targets;
    
    private void Awake()
    {
        StateMachine = new StateMachine();

        EatingState = new EatingState(this, StateMachine,this);
        WaitState = new WaitState(this, StateMachine);
        WalkState = new WalkState(this, StateMachine);
        IdleState = new IdleState(this, StateMachine);
    }

    private void Start()
    {
        StateMachine.Initialize(WalkState);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        var table = other.GetComponent<Table>();
        
        if (!table) return;
        table.Interact(this);
        StateMachine.ChangeState(EatingState);

    }

    private void Update()
    {
        StateMachine.CurrentState.FrameUpdate();
    }
    
}
