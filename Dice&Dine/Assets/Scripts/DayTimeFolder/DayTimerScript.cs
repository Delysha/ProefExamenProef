using UnityEngine;
using System;
public class DayTimerScript : MonoBehaviour
{
    [SerializeField] private float dayLengtheInSeconds = 120f;

    public Action OnDayFinished;

    private Transform clockHand;


    [Header("Countdown Sound")]
    [SerializeField] private AudioSource countdownSound;
    [SerializeField] private AudioSource final3SecSound;
    private bool countdownStarted = false;
    private bool final3Played = false;

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
          
            if (_currentTime <= 10f && !countdownStarted)
            {
                countdownStarted = true;
                countdownSound.Play(); 
            }

            // Speel korte sound in de laatste 3 seconden
            if (_currentTime <= 3f && !final3Played)
            {
                final3Played = true;
                final3SecSound.PlayOneShot(final3SecSound.clip);
            }

            if (_currentTime <= 0f)
            {
                _currentTime = 0;

                // Stop eventueel nog lopende sounds
                if (countdownSound.isPlaying) countdownSound.Stop();
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