using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, IWalkable, IWaitable, Iinteractable
{
    public npcTimer _timer;
    public StateMachine StateMachine { get; private set; }
    public EatingState EatingState { get; private set; }
    public WaitState WaitState { get; private set; }
    public WalkState WalkState { get; private set; }
    public IdleState IdleState { get; private set; }
    
    public int money;
    public int patience;
    public List<Transform> targets { get; set; }
    [SerializeField] private Transform interactionPoint;
    
    private void Awake()
    {
        StateMachine = new StateMachine();
        EatingState = new EatingState(this, StateMachine,this);
        WaitState = new WaitState(this, StateMachine);
        WalkState = new WalkState(this, StateMachine);
        IdleState = new IdleState(this, StateMachine);

        _timer = GetComponent<npcTimer>();
    }

    private void Start()
    {
        StateMachine.Initialize(WalkState);
    }

    private void Update()
    {
        StateMachine.CurrentState.FrameUpdate();
    }

    public Transform GetTransform()
    {
        return interactionPoint;
    }

    public void Interact(PlayerPickup player)
    {
        player.TryLead(this);
    }

    public void OnHoverEnter()
    {
        //Voor shader later
    }

    public void OnHoverExit()
    {
        //Voor shader later
    }
}
