using UnityEngine;

public class SaveOrder : MonoBehaviour
{
    [SerializeField] private GameObject[] drinks;

    public string orderdDrink;

    private void Start()
    {
        StoreOrder();
    }

    public void StoreOrder()
    {
        var orderdDrinkNumber = Random.Range(0, drinks.Length);

        GameObject orderdDrink = drinks[orderdDrinkNumber];
    }
}
