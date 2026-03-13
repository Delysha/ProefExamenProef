
using System.Collections;
using TMPro;
using UnityEngine;

public class RewardPanel : MonoBehaviour
{
    [SerializeField] private TextMeshPro rewardText;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector3 _vector = new Vector3();
    
    private float _time;

    private RewardPanel(int reward)
    {
        SetText(reward);
        StartCoroutine(UpTween());
    }

    private void Start()
    {
        _time = 2f;
        StartCoroutine(UpTween());
    }

    private IEnumerator UpTween()
    {
        yield return new WaitForSeconds(0f);
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            transform.Translate(0, Time.deltaTime, 0);
            var countdown = _time / 2f;
            rewardText.alpha = countdown;
            var color = _spriteRenderer.color;
            color.a = countdown;
            _spriteRenderer.color = color;
            StartCoroutine(UpTween());
        }
        else
        {
            StopCoroutine(UpTween());
        }
    }

    private void SetText(int amount)
    {
        rewardText.text = $"{amount}";
    }
}
