using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager: MonoBehaviour
{
    private Animator myAmimator;

    [SerializeField] private SaveOrder saveOrderScript;
    [SerializeField] private OrderSpotFilled orderSpotFilledScript;
    [SerializeField] private ThereIsOder thereIsOderScript;

    [SerializeField] private int _prepareDrinkTime;
    [SerializeField] GameObject[] _orderSpot;

    private void Start()
    {
        myAmimator = GetComponent<Animator>();
    }

    public IEnumerator PrepareDrinkRoutine()
    {
        var oder = thereIsOderScript.GetComponent<ThereIsOder>();

        for (int i = 0; i < _orderSpot.Length; i++)
        {
            var spot = _orderSpot[i].GetComponent<OrderSpotFilled>();

            if (!spot.SpotFilled && oder._oderOnPanel)
            {
                myAmimator.SetBool("IsPreparing", true);
                yield return new WaitForSeconds(_prepareDrinkTime);
                myAmimator.SetBool("IsPreparing", false);
                SetDrinkInSpot();
            }
            else
            {
                myAmimator.SetBool("IsPreparing", false);
            }
        }
    }

    private void SetDrinkInSpot()
    {
        for (int i = 0; i < _orderSpot.Length; i++)
        {
            var spot = _orderSpot[i].GetComponent<OrderSpotFilled>();

            var storeNumber = saveOrderScript.GetComponent<SaveOrder>();
            var order = storeNumber.OrderdDrink;

            var spotFilled = orderSpotFilledScript.GetComponent<OrderSpotFilled>();
            spotFilled.IsSpotFilled();

            storeNumber.StoreList();

            if (!spot.SpotFilled)
            {
                Instantiate(order, _orderSpot[i].transform);
                spot.SpotFilled = true;
                //Testing:
                //StartCoroutine(PrepareDrinkRoutine());
                storeNumber.StoreOrder();
                break;
            }
        }
    }
}