using UnityEngine;

public class SaveOrder : MonoBehaviour
{
    [SerializeField] private GameObject[] drinks;

    public GameObject orderdDrink;

    private void Start()
    {
        StoreOrder();
    }

    public void StoreOrder()
    {
        var orderdDrinkNumber = Random.Range(0, drinks.Length);

        orderdDrink = drinks[orderdDrinkNumber];
    }

    public void StoreList()
    {
        Debug.Log(orderdDrink);
    }
}