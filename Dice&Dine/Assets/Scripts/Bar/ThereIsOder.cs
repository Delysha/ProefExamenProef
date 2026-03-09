using UnityEngine;

public class ThereIsOder : MonoBehaviour
{
    [SerializeField] private BarManager barManagerScript;

    //SerializeField is voor testing
    [SerializeField] private bool _oderHasBeenMade;

    void Start()
    {
        barManagerScript = GetComponent<BarManager>();
    }

    void Update()
    {
        if (!_oderHasBeenMade) { return; } 
        StartCoroutine(barManagerScript.PrepareDrinkRoutine());
    }
}
