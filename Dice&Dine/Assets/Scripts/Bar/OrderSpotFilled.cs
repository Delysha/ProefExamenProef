using UnityEngine;

public class OrderSpotFilled : MonoBehaviour
{
    public bool SpotFilled;

    public void CheckIfSpotIsFilled()
    {
        SpotFilled = transform.childCount > 0;
    }
}
