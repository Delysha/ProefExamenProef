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
        HandleMouseUpdate();
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
}
