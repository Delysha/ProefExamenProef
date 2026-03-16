using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EconomyUI : MonoBehaviour
{
    private MainEconomy _mainEconomyScript;

    [Header("DailyQuotaText")]
    [SerializeField] private TMP_Text dailyQuotaText;
    private string _dailyQuotaTX;

    [Header("MoneyText")]
    [SerializeField] private TMP_Text moneyText;
    private string _moneyTX;

    private void Awake()
    {
        _mainEconomyScript = FindAnyObjectByType<MainEconomy>();
    }

    private void Update()
    {
        dailyQuotaText.text = _dailyQuotaTX + _mainEconomyScript.DailyQuota;
        moneyText.text = _moneyTX + _mainEconomyScript.Money;
    }
}
