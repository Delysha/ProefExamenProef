using UnityEngine;

public class npcSounds : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    [Header("NPC Sounds")]
    [SerializeField] private AudioClip handsUpSound;
    [SerializeField] private AudioClip frustratedSound;
    [SerializeField] private AudioClip satisfiedSound;

    private bool frustratedPlayed = false;

    public void PlayHandsUpSound()
    {
       if (audioSource && handsUpSound)
            audioSource.PlayOneShot(handsUpSound);
        frustratedPlayed = false;
    }

    public void CheckFrustrated(float patience)
    {
        if (patience <= 15f && !frustratedPlayed)
        {
            frustratedPlayed = true;

            if (audioSource && frustratedSound)
                audioSource.PlayOneShot(frustratedSound);
        }

    }

    public void PlaySatisfied()
    {
        if (audioSource && satisfiedSound)
            audioSource.PlayOneShot(satisfiedSound);
    }
}
