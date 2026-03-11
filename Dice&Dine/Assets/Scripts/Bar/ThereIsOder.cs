using UnityEngine;

public class ThereIsOder : MonoBehaviour, Iinteractable
{
    [Header("interactionPoint")]
    [SerializeField] private Transform _interactionPoint;
    [Header("Other Scripts")]
    [SerializeField] private BarManager barManagerScript;
    [Header("Sprite Renderer")]
    [SerializeField] private Sprite oderPanel1;
    [SerializeField] private Sprite oderPanel2;
    [Header("Highlight Settings")]
    [SerializeField] private SpriteRenderer _mySpriteRenderer;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Material _outlineMaterial;

    [Header("Check if there is an oder")]
    public bool _oderOnPanel;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _mySpriteRenderer.material = _normalMaterial;
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_oderOnPanel)
        {
            _spriteRenderer.sprite = oderPanel1;
        }
    }

    public Transform GetTransform() 
    {
        return _interactionPoint;
    }

    public void Interact(PlayerPickup player)
    {
        if (_oderOnPanel)
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
