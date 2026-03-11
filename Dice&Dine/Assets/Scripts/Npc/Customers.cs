using UnityEngine;

public class Customers : MonoBehaviour, Iinteractable
{
    [SerializeField] private Transform interactionPoint;

    public Transform GetTransform()
    {
        return interactionPoint;
    }

    public void Interact(PlayerPickup player)
    {
        player.TryLead(GetComponentInChildren<Customer>());
    }

    public void OnHoverEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnHoverExit()
    {
        throw new System.NotImplementedException();
    }
}
