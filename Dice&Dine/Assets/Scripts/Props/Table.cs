using System.Collections.Generic;
using UnityEngine;

public class Table : Props, Iinteractable
{
    [SerializeField] private List<Transform> itemSlots = new List<Transform>();
    [SerializeField] private List<Transform> slotSeats;
    
    [SerializeField] private Transform interactionPoint;
    private Dictionary<Transform, IPickupable> slotItems = new Dictionary<Transform, IPickupable>();
    private Dictionary<Transform, Customer> _slotSeats = new Dictionary<Transform, Customer>();
    
    private Material material;
    private static readonly int OutlineProperty = Shader.PropertyToID("_Outline");

    

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Initialiseer dictionary met alle slots
    public override void Initialize()
    {
        base.Initialize();
        
        foreach (var slot in itemSlots)
        {
            slotItems[slot] = null;
        }

        foreach (var seat in slotSeats)
        {
            _slotSeats[seat] = null;
        }
    }
    
    public Transform GetTransform()
    {
        return interactionPoint;
    }

    public void Interact(PlayerPickup player)
    {
        if (player.HasItem())
        {
            var availableSlot = GetAvailableItem();
            PlaceItem(player, availableSlot);
        }

        if (player.HasCustomer())
        {
            var availableSeat = GetAvailableSeat();
            PlaceCustomer(player, availableSeat);
        }

        
    }

    private Transform GetAvailableItem()
    {
        foreach (Transform slot in itemSlots)
        {
            if (slotItems[slot] == null)
                return slot;
        }
        return null;
    }
    
    private Transform GetAvailableSeat()
    {
        foreach (var slot in slotSeats)
        {
            if (!_slotSeats[slot] )
                return slot;
        }
        return null;
    }

    private void PlaceItem(PlayerPickup player, Transform slot)
    {
        IPickupable item = player.GetHeldItem();

        slotItems[slot] = item;

        player.Drop();

        MonoBehaviour itemAsMono = item as MonoBehaviour;
        itemAsMono.transform.position = slot.position;
        itemAsMono.transform.SetParent(slot);
    }

    private void PlaceCustomer(PlayerPickup player, Transform slot)
    {
        var customer = player.GetLeadingCustomer();

        _slotSeats[slot] = customer;
        
        player.PutToTable();
        
        var itemAsMono = customer as MonoBehaviour;
        itemAsMono.transform.position = slot.position;
        itemAsMono.transform.SetParent(slot);
    }

    public bool HasAvailableSlot()
    {
        return GetAvailableItem() != null;
    }

    public bool IsFull()
    {
        return GetAvailableItem() == null;
    }

    public void OnHoverEnter()
    {
        material.SetFloat(OutlineProperty, 1f);
    }

    public void OnHoverExit()
    {
        material.SetFloat(OutlineProperty, 0f);
    }
}
