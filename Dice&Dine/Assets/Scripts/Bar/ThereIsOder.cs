using UnityEngine;

public class ThereIsOder : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private BarManager barManagerScript;
    [SerializeField] private Sprite oderPanel1;
    [SerializeField] private Sprite oderPanel2;

    //SerializeField is voor testing
    [SerializeField] private bool _oderHasBeenMade;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        oderHasBeenMade();
    }

    private void oderHasBeenMade()
    {
        if (_oderHasBeenMade)
        {
            _spriteRenderer.sprite = oderPanel2;
            StartCoroutine(barManagerScript.PrepareDrinkRoutine());
        }
        else
        {
            _spriteRenderer.sprite = oderPanel1;
        }
    }
}
