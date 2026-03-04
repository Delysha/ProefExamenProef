using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBarBasis : MonoBehaviour
{
    [SerializeField] private SaveOrder saveOrder;

    [SerializeField] private int prepareDrinkTime;
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

            var storeNumber = saveOrder.GetComponent<SaveOrder>();
            var order = storeNumber.orderdDrink;

            storeNumber.StoreList();

            if (!spot.SpotFilled)
            {
                Instantiate(order, orderSpot[i].transform);
                spot.SpotFilled = true;
                //Testing:
                //StartCoroutine(PrepareDrinkRoutine());
                storeNumber.StoreOrder();
                break;
            }
        }
    }
}