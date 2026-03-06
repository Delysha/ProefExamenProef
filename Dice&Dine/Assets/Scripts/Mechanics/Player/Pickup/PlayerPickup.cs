using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;
    private IPickupable currentPickup;
    private Customer _customerTarget;

    public bool HasItem()
    {
        return currentPickup != null;
    }

    public bool HasCustomer()
    {
        return _customerTarget;
    }

    public void TryPickup(IPickupable item)
    {
        if(HasItem())
            return;

        currentPickup = item;
        currentPickup.OnPickup(holdPoint);
    }

    public void TryLead(Customer customer)
    {
        if (HasCustomer()) return;

        _customerTarget = customer;
        Debug.Log("JAAAA");
    }

    public void PutToTable()
    {
        Debug.Log("hey");
        if (!HasCustomer()) return;
        
        _customerTarget = null;
        
    }

    public void Drop()
    {
        if (!HasItem())
            return;

        currentPickup.OnDrop();
        currentPickup = null;
    }
    
    public Customer GetLeadingCustomer()
    {
        return _customerTarget;
    }

    public IPickupable GetHeldItem()
    {
        return currentPickup;
    }
}
