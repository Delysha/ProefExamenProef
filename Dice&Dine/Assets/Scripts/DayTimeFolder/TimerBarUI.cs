using UnityEngine;
using UnityEngine.UI;

public class TimerBarUI : MonoBehaviour
{
    public DayTimerScript dayTimer;
    public Image barImage;
    void Update()
    {
        barImage.fillAmount = dayTimer.GetNormalizedTime();
    }
}
