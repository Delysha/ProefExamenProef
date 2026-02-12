using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EconomyUI : MonoBehaviour
{
    private MainEconomy _mainEconomyScript;

    [Header("DailyQuotaText")]
    [SerializeField] private TMP_Text dailyQuotaText;
    [SerializeField] private string dailyQuotaTX;

    [Header("MoneyText")]
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private string moneyTX;

    private void Start()
    {
        _mainEconomyScript = FindAnyObjectByType<MainEconomy>();
    }

    private void Update()
    {
        dailyQuotaText.text = dailyQuotaTX + _mainEconomyScript.DailyQuota;
        moneyText.text = moneyTX + _mainEconomyScript.Money;
    }
}
