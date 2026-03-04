using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    [SerializeField] private int amountToPool;
    [SerializeField] private CustomerSpawner customerSpawner;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PooledObjects = new List<GameObject>();
        GameObject tmp;
        for(var i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(ObjectToPool);
            tmp.SetActive(false);
            PooledObjects.Add(tmp);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for(var i = 0; i < amountToPool; i++)
        {
            InitializeObject(PooledObjects[i].transform );
            if(!PooledObjects[i].activeInHierarchy) return PooledObjects[i];
        }
        return null;
    }

    private void InitializeObject(Transform pooledObject)
    {
        pooledObject.GetComponent<Customer>().targets = customerSpawner.Targets;
    }
    
    
    
}
