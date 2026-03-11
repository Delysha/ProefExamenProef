using UnityEngine;

public class ThereIsOder : MonoBehaviour, Iinteractable
{
    [Header("Highlight Settings")]
    [SerializeField] private SpriteRenderer _mySpriteRenderer;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Material _outlineMaterial;

    [SerializeField] private Transform _interractionPoint;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private BarManager barManagerScript;
    [SerializeField] private Sprite oderPanel1;
    [SerializeField] private Sprite oderPanel2;

    //SerializeField is voor testing
    [SerializeField] private bool _oderHasBeenMade;

    private void Awake()
    {
        _mySpriteRenderer.material = _normalMaterial;
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        oderHasBeenMade();
    }

    public Transform GetTransform() 
    {
        return _interractionPoint;
    }

    public void Interact(PlayerPickup player)
    {

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

    public void OnHoverEnter()
    {
        _mySpriteRenderer.material = _outlineMaterial;
    }

    public void OnHoverExit()
    {
        _mySpriteRenderer.material = _normalMaterial;
    }
}
