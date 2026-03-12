using System.Collections;
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
    [SerializeField] private TableOrder table;
    private Animator animator;

    private bool _wantsToOrder = false;

    [Header("Highlight Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material outlineMaterial;

    private void Awake()
    {
        StateMachine = new StateMachine();

        EatingState = new EatingState(this, StateMachine, this);
        WaitState = new WaitState(this, StateMachine);
        WalkState = new WalkState(this, StateMachine);
        IdleState = new IdleState(this, StateMachine);

        _timer = GetComponent<npcTimer>();
        animator = GetComponent<Animator>();

        if (spriteRenderer != null)
        {
            spriteRenderer.material = normalMaterial;
        }
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

    public void StartWaitingToOrder()
    {
        StartCoroutine(WaitBeforOrder());
    }

    public void RaiseHand()
    {
        _wantsToOrder = true;
        animator.SetBool("RaiseHand", true);
        //Debug.Log("Customer raised hand to order!");
    }

    IEnumerator WaitBeforOrder()
    {
        float waitTime = Random.Range(2f, 6f);

        yield return new WaitForSeconds(waitTime);
        
        RaiseHand();
    }

    public void Interact(PlayerPickup player)
    {
        player.TryLead(this);

        StateMachine.ChangeState(WaitState);

        if (!_wantsToOrder)
            return;

        //Debug.Log("Customer wants to order!");
        
        table.AddOrder();

        //animator.SetBool("RaiseHand", false);

        _wantsToOrder = false;
    }

    public void OnHoverEnter()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.material = outlineMaterial;
        }
    }

    public void OnHoverExit()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.material = normalMaterial;
        }
    }
}