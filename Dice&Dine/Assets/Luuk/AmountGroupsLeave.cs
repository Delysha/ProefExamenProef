using UnityEngine;

public class AmountGroupsLeave : MonoBehaviour
{
    private MainEconomy _mainEconnomyScript;

    [Header("Amount")]
    [SerializeField] private int maxAmount;
    [SerializeField] private int minAmount;

    private void Awake()
    {
        _mainEconnomyScript = FindAnyObjectByType<MainEconomy>();
    }

    private void Start()
    {
        /*GroupOne();
        GroupTwo();
        GroupThree();
        GroupFour();*/
    }

    //This groups holds 1 person
    private void GroupOne()
    {
        float randomAmount = Random.Range(minAmount, maxAmount);
        _mainEconnomyScript.Money += randomAmount;

        Debug.Log("Group one left " + randomAmount);
    }

    //This groups holds 2 persons
    private void GroupTwo() 
    {
        minAmount += 2;
        maxAmount += 2;

        float randomAmount = Random.Range(minAmount, maxAmount);
        _mainEconnomyScript.Money += randomAmount;

        Debug.Log("Group two left " + randomAmount);
    }

    //This groups holds 3 persons
    private void GroupThree() 
    {
        minAmount += 5;
        maxAmount += 5;

        float randomAmount = Random.Range(minAmount, maxAmount);
        _mainEconnomyScript.Money += randomAmount;

        Debug.Log("Group Three left " + randomAmount);
    }

    //This groups holds 4 persons
    private void GroupFour() 
    {
        minAmount += 8;
        maxAmount += 8;

        float randomAmount = Random.Range(minAmount, maxAmount);
        _mainEconnomyScript.Money += randomAmount;

        Debug.Log("Group four left " + randomAmount);
    }
}
