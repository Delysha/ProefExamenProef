using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Props, Iinteractable
{
    [SerializeField] private List<GameObject> places;
    
    [SerializeField] private Transform interactionPoint;
    private Dictionary<Transform, IPickupable> _slotItems = new Dictionary<Transform, IPickupable>();
    private Dictionary<Transform, Customer> _slotSeats = new Dictionary<Transform, Customer>();

    [Header("Highlight Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material outlineMaterial;

    private const float SlotRotation = 1f;

    private void Awake()
    {
        spriteRenderer.material = normalMaterial;
    }

    // Initialiseer dictionary met alle slots
    public override void Initialize()
    {
        base.Initialize();
        
        foreach (var place in places)
        {
            var placeScript = place.GetComponent<Place>();
            _slotItems[placeScript.plateSlot.transform] = null;
            _slotSeats[placeScript.seatSlot.transform] = null;
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
        foreach (var place in places)
        {
            var placeObj = place.GetComponent<Place>();
            var itemTransform = placeObj.plateSlot.transform;
            if (_slotItems[itemTransform] == null)
            {
                return itemTransform;
            }
        }

        return null;
    }
    
    private Transform GetAvailableSeat()
    {
        foreach (var place in places)
        {
            var placeObj = place.GetComponent<Place>();
            var seatTransform = placeObj.seatSlot.transform;

            if (_slotSeats[seatTransform] == null)
            {
                return seatTransform;
            }
        }

        return null;
    }

    private void PlaceItem(PlayerPickup player, Transform slot)
    {
        var item = player.GetHeldItem();
        
        _slotItems[slot] = item;
        
        player.Drop();
        var parent = slot.transform.parent;
        var seat = parent.GetChild(0);
        var customer = seat.GetComponentInChildren<Customer>();
        
        customer.StateMachine.ChangeState(customer.EatingState);
        MonoBehaviour itemAsMono = item as MonoBehaviour;
        
        itemAsMono.transform.position = slot.position;
        itemAsMono.transform.SetParent(slot);

        disableItem(item);
    }

    private void disableItem(IPickupable item)
    {
        item.Disable();
    }

    private void PlaceCustomer(PlayerPickup player, Transform slot)
    {
        var customer = player.GetLeadingCustomer();
        var sprite = customer.GetComponent<SpriteRenderer>();
        _slotSeats[slot] = customer;
        
        player.PutToTable();
        
        var customerMono = customer as MonoBehaviour;
        customerMono.transform.position = slot.position + new Vector3(0, 1f, 0);
        
        var yAxis = slot.rotation.y;
        var isRotated = Mathf.Approximately(yAxis, SlotRotation);
        sprite.flipX = isRotated;
        customerMono.transform.SetParent(slot);

        customer.StateMachine.ChangeState(customer.WaitState);
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
        spriteRenderer.material = outlineMaterial;
    }

    public void OnHoverExit()
    {
        spriteRenderer.material = normalMaterial;
    }
}
