using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource musicSource; // The AudioSource component for playing music
    public AudioClip backgroundMusic; // The music track to loop

    protected override void Awake()
    {
        base.Awake();

        if (musicSource == null)
        {
            Debug.LogError("AudioSource not assigned.");
        }

        // Set the music clip and make it loop
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;

        // Play the music
        PlayMusic();
    }

    // Function to play the music
    public void PlayMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play(); // Play the assigned background music
        }
    }

    // Function to stop the music
    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop(); // Stop the music
        }
    }
}
