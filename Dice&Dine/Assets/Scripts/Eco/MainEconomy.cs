using UnityEngine;

public class MainEconomy : MonoBehaviour
{
    public static MainEconomy Instance;

    [SerializeField] private RewardVisualizer rewardVisualizer;
    
    [Header("Amount the Customers can leave& Amount(To Test)")]
    [SerializeField] private int maxAmount;
    [SerializeField] private int minAmount;
    [SerializeField] private float amount;

    [Header("Money&DailyQuota")]
    public float Money;
    public int DailyQuota;

    [Header("Sound")]
    public AudioSource coinSound;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Debug.Log("The DailyQuota today is " + DailyQuota);
    }

    public void CustomerLeavesMoney(int receivedMoney)
    {
        Money += receivedMoney;
        rewardVisualizer.GeneratePanel(transform,Money);
        Debug.Log($"Money: {Money}" );
    }
}
