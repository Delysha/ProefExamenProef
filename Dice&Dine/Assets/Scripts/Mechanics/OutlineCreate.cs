using UnityEngine;

public class OutlineCreate : MonoBehaviour, Iinteractable
{
    [Header("Highlight Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material outlineMaterial;

    private void Awake()
    {
        spriteRenderer.material = normalMaterial;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerPickup player)
    {
       
    }

    public void OnHoverEnter()
    {
        spriteRenderer.material = outlineMaterial;
    }

    public void OnHoverExit()
    {
        spriteRenderer.material = normalMaterial;
    }
}
