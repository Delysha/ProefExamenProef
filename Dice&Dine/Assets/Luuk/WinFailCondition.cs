using UnityEngine;

public class WinFailCondition : MonoBehaviour
{
    private MainEconomy _mainEconoyScript;
    private DayTimerScript _dayTimerScript;

    private void Awake()
    {
        _mainEconoyScript = FindAnyObjectByType<MainEconomy>();
        _dayTimerScript = FindAnyObjectByType<DayTimerScript>();
    }

    private void Update()
    {
        _dayTimerScript.OndayFinished += handleDayFinished;
    }
    private void handleDayFinished()
    {
        DayCompleted();
        GameOver();
    }

    public void DayCompleted()
    {
        if (_mainEconoyScript.Money >= _mainEconoyScript.DailyQuota)
        {
            Debug.Log("You met the daily qouta");
        }
    }

    public void GameOver()
    {
        if (_mainEconoyScript.DailyQuota != _mainEconoyScript.Money && _mainEconoyScript.Money <= _mainEconoyScript.DailyQuota)
        {
            Debug.Log("You did not hit the daily quota");
        }
    }

    private void OnDestroy()
    {
        if (_dayTimerScript != null)
            _dayTimerScript.OndayFinished -= handleDayFinished;
    }
}
