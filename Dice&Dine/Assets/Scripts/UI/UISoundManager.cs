using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickClip;

    public void PlayClick()
    {
        if (audioSource != null && clickClip != null)
        {
            audioSource.PlayOneShot(clickClip);
        }
    }
}

