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
        if (transform.childCount > 0)
        {
            SpotFilled = true;
        }
        else
        {
            SpotFilled = false;
        }
    }
}
