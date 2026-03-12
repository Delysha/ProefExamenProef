using UnityEngine;

public class WinFailCondition : MonoBehaviour
{
    private MainEconomy _mainEconomyScript;
    private DayTimerScript _dayTimerScript;

    [Header("UI")]
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;

    private void Awake()
    {
        _mainEconomyScript = FindAnyObjectByType<MainEconomy>();
        _dayTimerScript = FindAnyObjectByType<DayTimerScript>();
    }

    private void Start()
    {
        _dayTimerScript.OnDayFinished += HandleDayFinished;

        winUI.SetActive(false);
        loseUI.SetActive(false);
    }

    private void HandleDayFinished()
    {
        if (_mainEconomyScript.Money >= _mainEconomyScript.DailyQuota)
        {
            Debug.Log("You met the daily quota!");
            winUI.SetActive(true);
        }
        else
        {
            Debug.Log("You did not hit the daily quota!");
            loseUI.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        if (_dayTimerScript != null)
            _dayTimerScript.OnDayFinished -= HandleDayFinished;
    }
}