using UnityEngine;

public class FailCondition : MonoBehaviour
{
    private MainEconomy _mainEconoyScript;

    private void Start()
    {
        _mainEconoyScript = FindAnyObjectByType<MainEconomy>();
    }

    private void Update()
    {
        GameOver();
    }

    public void GameOver()
    {
        if(_mainEconoyScript.DailyQuota != _mainEconoyScript.Money && _mainEconoyScript.Money <= _mainEconoyScript.DailyQuota) 
        {
            Debug.Log("You did not hit the daily quota");
        }
    }
}
