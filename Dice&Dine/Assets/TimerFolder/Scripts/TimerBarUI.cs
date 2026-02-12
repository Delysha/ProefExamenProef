using UnityEngine;
using UnityEngine.UI;

public class TimerBarUI : MonoBehaviour
{
    public DayTimerScript dayTimer;
    public Image barImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barImage.fillAmount = dayTimer.GetNormalizedTime();
    }
}
