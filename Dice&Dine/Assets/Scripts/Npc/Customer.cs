using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private GameObject _customer;
    private float _moveSpeed = 4f;
    private int _index = 0;
    [SerializeField] private int money;
    [SerializeField] private int patience;
    [SerializeField] private List<Transform> targets;
    

    private void Awake()
    {
        _customer = gameObject;
    }
    
    private void Update()
    {
        ToTarget();
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        NextTarget();
    }

    internal void ToTarget()
    {
        _customer.transform.position = Vector2.MoveTowards(transform.position, targets[_index].position, _moveSpeed * Time.deltaTime);
    }
    
    internal void NextTarget()
    {
        _index += 1;
            
        if (_index > targets.Count -1)
            _index = 0;
    }
}
