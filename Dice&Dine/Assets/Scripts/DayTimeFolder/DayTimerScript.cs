using UnityEngine;
using System;
public class DayTimerScript : MonoBehaviour
{
    [SerializeField] private float dayLengtheInSeconds = 120f;

    public Action OnDayFinished;

    private float _currentTime;
    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                _currentTime = 0;
                OnDayEnded();
            }
        }
    }

    public void ResetTimer()
    {
        _currentTime = dayLengtheInSeconds;
    }

    public float GetNormalizedTime()
    {
        return _currentTime / dayLengtheInSeconds;
    }

    private void OnDayEnded()
    {
        Debug.Log("Dag is voorbij!");

        OnDayFinished?.Invoke();
    }
    
}
