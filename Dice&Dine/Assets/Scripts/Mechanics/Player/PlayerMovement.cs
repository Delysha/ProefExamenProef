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

    [Header("Debug")]
    [SerializeField] private bool enableDebugLogs = false;

    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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

    // Update is called once per frame
    private void Update()
    {
        HandleDropInput();
        HandleMouseUpdate();
    }

    private void HandleDropInput()
    {
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        PlayerPickup pickupSystem = GetComponent<PlayerPickup>();
        if (pickupSystem == null || !pickupSystem.HasItem())
        {
            return;
        }

        pickupSystem.Drop();
    }

    private void HandleMouseUpdate()
    {
         if (Input.GetMouseButtonDown(0))
        {
            Camera camera = Camera.main;
            if (camera == null)
            {
                return;
            }

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(camera.transform.position.z - transform.position.z);
            Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(mousePosition);
            Vector3 target = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, transform.position.z);

            if (TryInteractAt(mouseWorldPosition))
            {
                return;
            }

            if (NavMesh.SamplePosition(target, out NavMeshHit hit, sampleRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);

                if (enableDebugLogs)
                {
                    Debug.Log($"Click: destination={hit.position}", this);
                }
            }
            else if (enableDebugLogs)
            {
                Debug.Log($"Click ignored: no NavMesh near {target}.", this);
            }
        }
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
        IPickupable pickupable = clickedObject.GetComponent<IPickupable>();

        if (pickupable != null)
        {
            PlayerPickup pickupSystem = GetComponent<PlayerPickup>();
            pickupSystem.TryPickup(pickupable);
        }
    }

}
