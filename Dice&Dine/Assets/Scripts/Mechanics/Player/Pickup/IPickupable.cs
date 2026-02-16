using UnityEngine;

public interface IPickupable
{
    void OnPickup(Transform holdPoint);
    void OnDrop();
}
