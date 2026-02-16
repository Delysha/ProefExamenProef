using UnityEngine;

public class PickupItem : MonoBehaviour , IPickupable
{
    private Rigidbody2D rb;
    private Collider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    public void OnPickup(Transform holdPoint)
    {
        if (rb != null)
            rb.simulated = false;

        if (col != null)
            col.enabled = false;

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrop()
    {
        if (rb != null)
            rb.simulated = true;

        if (col != null)
            col.enabled = true;

        transform.SetParent(null);
    }
}
