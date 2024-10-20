using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource musicSource; // The audio source component that will play the music
    public List<AudioClip> musicTracks; // A list of available music tracks
    private AudioClip currentTrack; // The currently playing track
    public float transitionDuration = 1f; // Time in seconds for music transitions

    protected override void Awake()
    {
        base.Awake();
        if (musicSource == null)
        {
            Debug.LogError("AudioSource not assigned.");
        }
    }

    // Call this to play a specific track by index
    public void PlayMusic(int trackIndex)
    {
        if (trackIndex < 0 || trackIndex >= musicTracks.Count)
        {
            Debug.LogError("Track index out of range.");
            return;
        }

        AudioClip newTrack = musicTracks[trackIndex];

        // If the track is already playing, do nothing
        if (newTrack == currentTrack)
        {
            Debug.Log("Track is already playing.");
            return;
        }

        // Start the transition to the new track
        StartCoroutine(TransitionMusic(newTrack));
    }

    // Smooth transition from the current track to the new track
    private IEnumerator TransitionMusic(AudioClip newTrack)
    {
        // Fade out the current music
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            musicSource.volume = Mathf.Lerp(1f, 0f, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Change the track and fade in the new music
        musicSource.Stop(); // Stop the current track
        musicSource.clip = newTrack; // Set the new track
        currentTrack = newTrack;
        musicSource.Play(); // Start the new track

        // Fade in the new track
        elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            musicSource.volume = Mathf.Lerp(0f, 1f, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    // Stop the current music immediately
    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
            currentTrack = null;
        }
    }

    // Pause the current music
    public void PauseMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }

    // Resume the music after pausing
    public void ResumeMusic()
    {
        if (!musicSource.isPlaying && currentTrack != null)
        {
            musicSource.UnPause();
        }
    }
}
