using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;
    public List<GameObject> PooledObjects;
    public List<GameObject> ObjectToPool;
    [SerializeField] private int amountToPool;
    [SerializeField] private CustomerSpawner customerSpawner;
    
    private void Awake()
    {
        Instance = this;
    }
    //private void Start()
    //{
    //    GameObject tmp;
    //    for(var i = 0; i < amountToPool; i++)
    //    {
    //        var randomIndex = Random.Range(0, ObjectToPool.Count - 1);
    //        tmp = Instantiate(ObjectToPool[randomIndex]);
    //        tmp.SetActive(false);
    //        PooledObjects.Add(tmp);
    //    }
    //}
    
    public GameObject GetPooledObject()
    {
        for(var i = 0; i < amountToPool; i++)
        {
            if(!PooledObjects[i].activeInHierarchy) return PooledObjects[i];
        }
        return null;
    }
    
    
    
    
}
