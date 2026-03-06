using UnityEngine;

public class PickupItem : MonoBehaviour , IPickupable , Iinteractable
{
    private Rigidbody2D rb;
    private Collider2D col;
    private Material material;
    private static readonly int OutlineProperty = Shader.PropertyToID("_Outline");

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerPickup player)
    {
        player.TryPickup(this);
    }

    public void SetHighlight(bool value)
    {

    }

    public void OnHoverEnter()
    {
        if (material != null)
        {
            Debug.Log($"OnHoverEnter called on {gameObject.name}. Setting outline to 1", this);
            material.SetFloat(OutlineProperty, 1f);
        }
        else
        {
            Debug.LogWarning($"OnHoverEnter: Material is null on {gameObject.name}", this);
        }
    }

    public void OnHoverExit()
    {
        if (material != null)
        {
            Debug.Log($"OnHoverExit called on {gameObject.name}. Setting outline to 0", this);
            material.SetFloat(OutlineProperty, 0f);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            material = spriteRenderer.material;
            Debug.Log($"PickupItem {gameObject.name}: Material = {material.name}, Shader = {material.shader.name}", this);
            
            // Check of de shader de _Outline property heeft
            if (material.HasProperty(OutlineProperty))
            {
                Debug.Log($"Shader heeft _Outline property!", this);
            }
            else
            {
                Debug.LogWarning($"Shader '{material.shader.name}' heeft GEEN _Outline property!", this);
            }
        }
        else
        {
            Debug.LogError($"PickupItem {gameObject.name}: Geen SpriteRenderer gevonden!", this);
        }
    }

    private bool IsInitialized()
    {
        return rb != null && col != null;
    }

    public void OnPickup(Transform holdPoint)
    {
        if (IsInitialized())
        {
            rb.simulated = false;
            col.enabled = false;
        }

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrop()
    {
        if (IsInitialized())
        {
            rb.simulated = true;
            col.enabled = true;
        }

        transform.SetParent(null);
    }
}
