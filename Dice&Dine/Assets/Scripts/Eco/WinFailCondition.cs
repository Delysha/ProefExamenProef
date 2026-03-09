using UnityEngine;

public class WinFailCondition : MonoBehaviour
{
    private MainEconomy _mainEconoyScript;

    private void Awake()
    {
        _mainEconoyScript = FindAnyObjectByType<MainEconomy>();
    }

    private void Update()
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
}
