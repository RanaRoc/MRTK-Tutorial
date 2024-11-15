using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips;

    private int currentClipIndex = 0;
    private bool isPlaying = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Call this function to play the next sound
    public void PlayNextSound()
    {
        if (audioClips == null || audioClips.Count == 0 || isPlaying)
            return;

        // Check if there are more clips to play
        if (currentClipIndex < audioClips.Count)
        {
            AudioClip clip = audioClips[currentClipIndex];
            audioSource.clip = clip;
            audioSource.Play();
            isPlaying = true;

            // Start a coroutine to wait until the sound finishes
            StartCoroutine(WaitForSoundToEnd());
        }
    }

    private IEnumerator WaitForSoundToEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        isPlaying = false;
        currentClipIndex++;

        // If you want to loop back to the first sound, uncomment the following line:
        // currentClipIndex %= audioClips.Count;
    }

    // Call this to reset and start from the first sound again
    public void ResetSoundSequence()
    {
        currentClipIndex = 0;
        isPlaying = false;
    }
}
