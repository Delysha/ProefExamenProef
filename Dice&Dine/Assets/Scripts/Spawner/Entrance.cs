using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public List<Transform> EntranceRow;
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        var waitRow = GetComponentsInChildren<Transform>();
        foreach (var rowIndex in waitRow)
        {
            if (rowIndex.name == "RowSeat")
            {
                EntranceRow.Add(rowIndex);
            }
        }
    }
    
}
