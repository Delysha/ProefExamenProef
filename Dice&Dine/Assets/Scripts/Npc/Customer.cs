using System;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, IWalkable, IWaitable
{
    public StateMachine StateMachine { get; set; }
    public EatingState EatingState { get; set; }
    public WaitState WaitState { get; set; }
    public WalkState WalkState { get; set; }
    
    public int money;
    public int patience;
    public List<Transform> targets;
    
    public float MoveSpeed = 4f;
    
    private void Awake()
    {
        StateMachine = new StateMachine();

        EatingState = new EatingState(this, StateMachine);
        WaitState = new WaitState(this, StateMachine);
        WalkState = new WalkState(this, StateMachine);

    }

    private void Start()
    {
        StateMachine.Initialize(WalkState);
    }

    private void Update()
    {
        StateMachine.currentState.FrameUpdate();
    }
    
}
