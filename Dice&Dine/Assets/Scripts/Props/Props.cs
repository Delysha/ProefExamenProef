using System;
using UnityEngine;

public class Props : MonoBehaviour
{
    private void Start()
    {
        Initialize();
    }

    public virtual void Initialize() {}

    public virtual void Interact(Customer customer) {}
}

