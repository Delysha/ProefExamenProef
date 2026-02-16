using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;
    private IPickupable currentPickup;

    public bool HasItem()
    {
        return currentPickup != null;
    }

    public void TryPickup(IPickupable item)
    {
        if(HasItem())
        return;

        currentPickup = item;
        currentPickup.OnPickup(holdPoint);
    }

    public void Drop()
    {
        if (!HasItem())
            return;

        currentPickup.OnDrop();
        currentPickup = null;
    }
}
