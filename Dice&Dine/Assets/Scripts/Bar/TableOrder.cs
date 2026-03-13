using UnityEngine;

public class TableOrder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] orderSprites;

    private int currentOrders = 0;

    public void AddOrder()
    {
        currentOrders++;

        currentOrders = Mathf.Clamp(currentOrders, 0, 4);

        spriteRenderer.sprite = orderSprites[currentOrders - 1];
    }
}
