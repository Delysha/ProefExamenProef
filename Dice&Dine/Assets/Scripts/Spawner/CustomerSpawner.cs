using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public List<Transform> Targets;
    [SerializeField] private Entrance Entrance;
    [SerializeField] private ObjectPooling objectPooling;
    [SerializeField] private int amountCustomers;
    [SerializeField] private Transform outsidePos;
    [SerializeField] private List<GameObject> outsideCustomers = new List<GameObject>();
    private void Start()
    {
        SpawnCustomers();
    }

    private void SpawnCustomers()
    {

        for (var i = 0; i < amountCustomers; i++)
        {
            var customerObject = objectPooling.GetPooledObject();
            SetCustomerPos(customerObject, Entrance, i);
        } 
    }
    
    
    private void SetCustomerPos(GameObject customer, Entrance entranceRow, int index)
    {
        customer.SetActive(true);
        if (index < 6)
        {
            customer.transform.position = entranceRow.EntranceRow[index].transform.position;
        }
        if (index >= 6)
        {
            outsideCustomers.Add(customer);
            customer.transform.position = outsidePos.transform.position;
        }
    }
    
}
