using UnityEngine;

public class MainEconomy : MonoBehaviour
{
    [Header("Amount the Customers can leave& Amount(To Test)")]
    [SerializeField] private int maxAmount;
    [SerializeField] private int minAmount;
    [SerializeField] private float amount;

    [Header("Money&DailyQuota")]
    public float Money;
    public int DailyQuota;

    private void Start()
    {
        Debug.Log("The DailyQuota today is " + DailyQuota);
    }

    private void Update()
    {
        Debug.Log("Your current money is " + Money);

        CheatMoney();

        CustomerLeavesMoney();
    }

    private void CheatMoney()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Money += amount;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Money -= amount;
        }
    }

    private void CustomerLeavesMoney()
    {
        //Remove Input, this is just for testing
        if (Input.GetKeyDown(KeyCode.P))
        {
            float randomAmount = Random.Range(minAmount, maxAmount);
            Money += randomAmount;
        }
    }
}
