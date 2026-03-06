using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;
    private IPickupable _currentPickup;
    private Customer _customerTarget;

    public bool HasItem()
    {
        return _currentPickup != null;
    }

    public bool HasCustomer()
    {
        return _customerTarget;
    }

    public void TryPickup(IPickupable item)
    {
        if(HasItem())
            return;

        _currentPickup = item;
        _currentPickup.OnPickup(holdPoint);
    }

    public void TryLead(Customer customer)
    {
        if (HasCustomer()) return;

        _customerTarget = customer;
    }

    public void PutToTable()
    {
        if (!HasCustomer()) return;
        
        _customerTarget = null;
        
    }

    public void Drop()
    {
        if (!HasItem())
            return;

        _currentPickup.OnDrop();
        _currentPickup = null;
    }
    
    public Customer GetLeadingCustomer()
    {
        return _customerTarget;
    }

    public IPickupable GetHeldItem()
    {
        return _currentPickup;
    }
}
