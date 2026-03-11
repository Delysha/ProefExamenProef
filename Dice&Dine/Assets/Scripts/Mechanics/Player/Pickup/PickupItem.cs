using UnityEngine;

public class PickupItem : MonoBehaviour , IPickupable , Iinteractable
{
    private Rigidbody2D rb;
    private Collider2D col;

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerPickup player)
    {
        player.TryPickup(this);
    }

    public void OnHoverEnter()
    {
        // Later: outline shader aanzetten
    }

    public void OnHoverExit()
    {
        // Later: outline shader uitzetten
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private bool IsInitialized()
    {
        return rb != null && col != null;
    }

    public void OnPickup(Transform holdPoint)
    {
        if (IsInitialized())
        {
            rb.simulated = false;
            col.enabled = false;
        }

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrop()
    {
        if (IsInitialized())
        {
            rb.simulated = true;
            col.enabled = true;
        }

        transform.SetParent(null);
    }
}
