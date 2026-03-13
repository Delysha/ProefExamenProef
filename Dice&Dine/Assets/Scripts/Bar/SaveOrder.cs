using UnityEngine;

public class SaveOrder : MonoBehaviour
{
    [SerializeField] private GameObject[] _drinks;

    public GameObject OrderdDrink;

    private void Start()
    {
        StoreOrder();
    }

    public void StoreOrder()
    {
        var orderdDrinkNumber = Random.Range(0, _drinks.Length);

        OrderdDrink = _drinks[orderdDrinkNumber];
    }

    public void StoreList()
    {
        Debug.Log(OrderdDrink);
    }
}