using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private MainEconomy _mainEconoyScript;

    private void Start()
    {
        _mainEconoyScript = FindAnyObjectByType<MainEconomy>();
    }

    private void Update()
    {
        DayCompleted();
    }

    public void DayCompleted()
    {
        if(_mainEconoyScript.Money >= _mainEconoyScript.DailyQuota)
        {
            Debug.Log("You met the daily qouta");
        }
    }
}
