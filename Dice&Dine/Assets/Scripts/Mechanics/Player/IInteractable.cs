using UnityEngine;

public interface Iinteractable 
{
    Transform GetTransform();
    void Interact(PlayerPickup player);
    void OnHoverEnter();
    void OnHoverExit();
}
