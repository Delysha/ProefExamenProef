using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager: MonoBehaviour
{
    private Animator myAmimator;

    [SerializeField] private SaveOrder saveOrder;
    [SerializeField] private OrderSpotFilled orderSpotFilled;

    [SerializeField] private int prepareDrinkTime;
    [SerializeField] GameObject[] orderSpot;

    private void Start()
    {
        myAmimator = GetComponent<Animator>();
    }

    public IEnumerator PrepareDrinkRoutine()
    {
        for (int i = 0; i < orderSpot.Length; i++)
        {
            var spot = orderSpot[i].GetComponent<OrderSpotFilled>();

            if (!spot.SpotFilled) 
            {
                myAmimator.SetBool("IsPreparing", true);
                yield return new WaitForSeconds(prepareDrinkTime);
                myAmimator.SetBool("IsPreparing", false);
                SetDrinkInSpot();
            }
        }
    }

    private void SetDrinkInSpot()
    {
        for (int i = 0; i < orderSpot.Length; i++)
        {
            var spot = orderSpot[i].GetComponent<OrderSpotFilled>();

            var storeNumber = saveOrder.GetComponent<SaveOrder>();
            var order = storeNumber.orderdDrink;

            var spotFilled = orderSpotFilled.GetComponent<OrderSpotFilled>();
            spotFilled.IsSpotFilled();

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