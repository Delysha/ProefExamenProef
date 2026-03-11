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

    [SerializeField] private GameObject orderTicketPrefab;
    [SerializeField] private Transform ticketSpawnPoint;

    private bool _wantsToOrder = false;

    private void Awake()
    {
        StateMachine = new StateMachine();

        EatingState = new EatingState(this, StateMachine, this);
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

    public void RaiseHand()
    {
        _wantsToOrder = true;
    }

    public void Interact(PlayerPickup player)
    {
        // eerst proberen de customer te leiden naar een tafel
        player.TryLead(this);

        if (!_wantsToOrder)
            return;

        if (player.HasItem())
            return;

        GameObject ticket = Instantiate(orderTicketPrefab, ticketSpawnPoint.position, Quaternion.identity);

        IPickupable pickup = ticket.GetComponent<IPickupable>();

        player.TryPickup(pickup);

        _wantsToOrder = false;
    }

    public void OnHoverEnter()
    {
        // outline shader later
    }

    public void OnHoverExit()
    {
        // outline shader later
    }
}