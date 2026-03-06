using UnityEngine;

public interface Iinteractable 
{
    Transform GetTransform();
    void Interact(PlayerPickup player);
    void SetHighlight(bool value);
    void OnHoverEnter();
    void OnHoverExit();
}
