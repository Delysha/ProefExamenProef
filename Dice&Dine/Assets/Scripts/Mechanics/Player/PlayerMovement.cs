using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float stoppingDistance = 0.1f;

    [Header("NavMesh Settings")]
    [SerializeField] private float sampleRadius = 2f;

    [Header("Interaction Settings")]
    [SerializeField] private float interactDistance = 1.5f;
    private Iinteractable currentInteractable;

    [Header("Debug")]
    [SerializeField] private bool enableDebugLogs = false;

    private NavMeshAgent agent;
   
    private Animator _playerAnimator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _targetPos;
    private Vector2 _movement;
    private bool isMoving = false;
    
    Vector2 lastDirection;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _playerAnimator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = moveSpeed;
        agent.stoppingDistance = stoppingDistance;
        agent.isStopped = false;

        if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, sampleRadius, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
        }
        else if (enableDebugLogs)
        {
            Debug.Log("NavMesh: player is not on a NavMesh at start.", this);
        }
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
        
        AnimationController();

        if (currentInteractable != null)
        {
            float distance = Vector3.Distance(transform.position, currentInteractable.GetTransform().position);
           
            if (distance <= interactDistance)
            {
                currentInteractable.Interact(GetComponent<PlayerPickup>());
                currentInteractable.OnHoverExit();
                currentInteractable = null;
            }
        }
        
        HandleDropInput();
    }
    
    private void AnimationController()
    {
        var velocity = agent.velocity;

        var direction = new Vector2(agent.velocity.x, agent.velocity.y);
        
        if (velocity.magnitude > 0.01f)
        {
            lastDirection = new Vector2(velocity.x, velocity.y).normalized;
        }

        var isRightSided = agent.velocity.x > 0.05f;
        
        _spriteRenderer.flipX = isRightSided;
        
        _playerAnimator.SetFloat("Horizontal", direction.x);
        _playerAnimator.SetFloat("Vertical", direction.y);
        _playerAnimator.SetFloat("Speed", velocity.magnitude);
    }

    private void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (currentInteractable != null)
        {
            currentInteractable.OnHoverExit();
            currentInteractable = null;
        }

        if (hit.collider != null)
        {
            Iinteractable interactable = hit.collider.GetComponent<Iinteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                currentInteractable.OnHoverEnter();
                MoveTo(interactable.GetTransform().position);
                return;
            }

            var pickupable = hit.collider.GetComponent<IPickupable>();
            if (pickupable != null && TryInteractAt(hit.point))
            {
                return;
            }
        }

        // Anders: normale movement
        MoveTo(GetMouseWorldPosition());
    }

    private void HandleDropInput()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        PlayerPickup pickupSystem = GetComponent<PlayerPickup>();

        if (pickupSystem.HasItem()) pickupSystem.Drop();

        if (pickupSystem.HasCustomer()) pickupSystem.PutToTable();
    }

    private bool TryInteractAt(Vector3 worldPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        if (hit.collider == null)
        {
            return false;
        }

        GameObject clickedObject = hit.collider.gameObject;
        if (clickedObject.GetComponent<IPickupable>() == null)
        {
            return false;
        }

        float distance = Vector2.Distance(transform.position, clickedObject.transform.position);
        if (distance > interactDistance)
        {
            if (enableDebugLogs)
            {
                Debug.Log($"Interact ignored: too far ({distance:0.00} > {interactDistance:0.00}).", this);
            }

            return false;
        }
        TryInteract(clickedObject);
        return true;
    }

    private void TryInteract(GameObject clickedObject)
    {
        var pickupable = clickedObject.GetComponent<IPickupable>();
        var customer = clickedObject.GetComponent<Customer>();
        
        PlayerPickup pickupSystem = GetComponent<PlayerPickup>();
        
        if (pickupable != null)
        {
            pickupSystem.TryPickup(pickupable);
        }

        if (customer != null)
        {
            pickupSystem.TryLead(customer);
        }
    }

    private void MoveTo(Vector3 targetPosition)
    {
        Vector3 target = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        if (NavMesh.SamplePosition(target, out NavMeshHit hit, sampleRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);

            if (enableDebugLogs)
            {
                Debug.Log($"MoveTo: destination={hit.position}", this);
            }
        }
        else if (enableDebugLogs)
        {
            Debug.Log($"MoveTo ignored: no NavMesh near {target}.", this);
        }
    }
    
   

    private Vector3 GetMouseWorldPosition()
    {
        Camera camera = Camera.main;
        if (camera == null)
        {
            return transform.position;
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(camera.transform.position.z - transform.position.z);
        return camera.ScreenToWorldPoint(mousePosition);
    }
}
