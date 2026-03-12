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

    public List<Transform> targets { get; set; }

    [SerializeField] private Transform interactionPoint;

    public bool hasSeat = false;
    //[SerializeField] private TableOrder table;
    private Animator animator;

    private bool _wantsToOrder = false;

    private ThereIsOder orderMenu;

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
        orderMenu = FindObjectOfType<ThereIsOder>();

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
    }

    IEnumerator WaitBeforOrder()
    {
        float waitTime = Random.Range(2f, 6f);

        yield return new WaitForSeconds(waitTime);
        
        RaiseHand();
    }

    private void Order()
    {
        orderMenu._oderOnPanel = true;
    }

    public void Interact(PlayerPickup player)
    {
        Debug.Log(hasSeat);
        if (!hasSeat)
        {
            player.TryLead(this);
            hasSeat = true;
        } 
       

        if (!_wantsToOrder)
            return;

        Debug.Log("Customer wants to order!");

        Order();
        //table.AddOrder();

        animator.SetBool("RaiseHand", false);

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