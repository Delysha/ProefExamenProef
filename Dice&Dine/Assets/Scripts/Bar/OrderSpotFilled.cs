using UnityEngine;

public class OrderSpotFilled : MonoBehaviour
{
    public bool SpotFilled;

    void Update()
    {
        CheckIfSpotIsFilled();
    }

    private void CheckIfSpotIsFilled()
    {
        SpotFilled = transform.childCount > 0;
    }
}
