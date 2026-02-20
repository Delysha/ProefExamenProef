using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, Iinteractable
{
    [SerializeField] private List<Transform> itemSlots = new List<Transform>();
    [SerializeField] private Transform interactionPoint;
    private Dictionary<Transform, IPickupable> slotItems = new Dictionary<Transform, IPickupable>();
    
    private Material material;
    private static readonly int OutlineProperty = Shader.PropertyToID("_Outline");

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        // Initialiseer dictionary met alle slots
        foreach (Transform slot in itemSlots)
        {
            slotItems[slot] = null;
        }
    }

    public Transform GetTransform()
    {
        return interactionPoint;
    }

    public void Interact(PlayerPickup player)
    {
        if (!player.HasItem())
            return;

        Transform availableSlot = GetAvailableSlot();
        if (availableSlot == null)
            return;

        PlaceItem(player, availableSlot);
    }

    private Transform GetAvailableSlot()
    {
        foreach (Transform slot in itemSlots)
        {
            if (slotItems[slot] == null)
            {
                return slot;
            }
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

    public bool HasAvailableSlot()
    {
        return GetAvailableSlot() != null;
    }

    public bool IsFull()
    {
        return GetAvailableSlot() == null;
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
