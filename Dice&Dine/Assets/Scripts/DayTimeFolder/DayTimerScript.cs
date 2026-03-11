using UnityEngine;
using System;
public class DayTimerScript : MonoBehaviour
{
    [SerializeField] private float dayLengtheInSeconds = 120f;

    public Action OnDayFinished;

    private Transform clockHand;

    private float _currentTime;
    void Start()
    {
        GameObject wijzerObj = GameObject.Find("Wijzer");

        if (wijzerObj != null)
        {
            clockHand = wijzerObj.transform;
        }
        else
        {
            Debug.LogWarning("Kan wijzer niet vinden in scene");
        }

        ResetTimer();
    }

    void Update()
    {
        UpdateTimer();
        updateClockHand();
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

    private void updateClockHand()
    {
        if (clockHand == null) return;

        float normalizedTime = GetNormalizedTime();
        float angle =  normalizedTime * 360f;

        clockHand.localRotation = Quaternion.Euler(0f, 0f, -angle);

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