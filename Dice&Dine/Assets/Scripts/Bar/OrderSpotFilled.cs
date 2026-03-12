using UnityEngine;

public class OrderSpotFilled : MonoBehaviour
{
    public bool SpotFilled;

    private void Update()
    {
        IsSpotFilled();
    }

    public void IsSpotFilled()
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
