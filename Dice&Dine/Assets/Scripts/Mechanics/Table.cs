using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, Iinteractable
{
    [SerializeField] private List<Transform> itemSlots = new List<Transform>();
    [SerializeField] private Transform interactionPoint;

    [Header("Highlight Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material outlineMaterial;

    private Dictionary<Transform, IPickupable> slotItems = new Dictionary<Transform, IPickupable>();

    private void Awake()
    {
        spriteRenderer.material = normalMaterial;

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

    public void SetHighlight(bool value)
    {
        spriteRenderer.material = value ? outlineMaterial : normalMaterial;
    }

    public void OnHoverEnter()
    {
        spriteRenderer.material = outlineMaterial;
    }

    public void OnHoverExit()
    {
        spriteRenderer.material = normalMaterial;
    }

    private Transform GetAvailableSlot()
    {
        foreach (Transform slot in itemSlots)
        {
            if (slotItems[slot] == null)
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

    public bool HasAvailableSlot()
    {
        return GetAvailableSlot() != null;
    }

    public bool IsFull()
    {
        return GetAvailableSlot() == null;
    }
}