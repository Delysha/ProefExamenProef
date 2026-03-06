using UnityEngine;

public class OrderSpotFilled : MonoBehaviour
{
    public bool SpotFilled;

    public void IsSpotFilled()
    {
        SpotFilled = transform.childCount > 0;
    }
}
