using System.Collections.Generic;
using UnityEngine;
public class Table : Props
{
    [SerializeField] private List<Transform> _seats;
    public bool _isOccupied { get; private set; }
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
        _isOccupied = true;
        customer.transform.position = _seats[0].transform.position;
    }
}
