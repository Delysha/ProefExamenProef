using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBarBasis : MonoBehaviour
{
    [SerializeField] private SaveOrder _saveOrder;

    [SerializeField] private int prepareDrinkTime;
    [SerializeField] private GameObject[] drinks;
    [SerializeField] GameObject[] orderSpot;

    private void Start()
    {
        StartCoroutine(PrepareDrinkRoutine());
    }

    IEnumerator PrepareDrinkRoutine()
    {
        yield return new WaitForSeconds(prepareDrinkTime);
        SetDrinkInSpot();
    }

    private void SetDrinkInSpot()
    {
        for (int i = 0; i < orderSpot.Length; i++)
        {
            var spot = orderSpot[i].GetComponent<OrderSpotFilled>();

            var storeNumber = _saveOrder.GetComponent<SaveOrder>();
            var order = storeNumber.orderdDrink;

            if (!spot.SpotFilled)
            {
                Instantiate(drinks[i], orderSpot[i].transform);
                spot.SpotFilled = true;
                //Testing: StartCoroutine(PrepareDrinkRoutine());
                break;
            }
        }
    }
}