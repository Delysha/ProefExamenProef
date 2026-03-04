using System.Collections.Generic;
using UnityEngine;
public class Tabless : Props
{
    [SerializeField] private List<Transform> _seats;
    public bool IsOccupied { get; private set; }
    public override void Initialize()
    {
        base.Initialize();
        var seats = GetComponentsInChildren<Transform>();
        foreach (var seat in seats)
        {
            if (seat.name.Contains($"Chair({seat.GetSiblingIndex()})"))
                _seats.Add(seat);
        }
    }

    public override void Interact(Customer customer)
    {
        IsOccupied = true;
        customer.transform.position = _seats[0].transform.position;
    }
}
