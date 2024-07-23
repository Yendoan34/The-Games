using UnityEngine;
using UnityEngine.UI; // Make sure to include this if using UI elements like Slider

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sounds")]
    public AudioClip[] sounds;
    public string[] soundNames;

    [Header("Music")]
    public AudioClip[] musicTracks;
    public string[] musicNames;

    [Header("UI")]
    public Slider musicVolumeSlider; // Reference to the music volume slider
    public Slider soundVolumeSlider; // Reference to the music volume slider
    private AudioSource soundSource;
    private AudioSource musicSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            // Store the old instance's volume settings
            float oldSoundVolume = instance.soundSource.volume;
            float oldMusicVolume = instance.musicSource.volume;

            // Destroy the old instance
            Destroy(instance.gameObject);

            // Set this instance as the current one
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Add audio sources
            soundSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true; // Make sure music loops automatically

            // Transfer the volume settings to the new instance
            soundSource.volume = oldSoundVolume;
            musicSource.volume = oldMusicVolume;
        }
        else if (instance == null)
        {
            // Set this instance as the current one
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Add audio sources
            soundSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true; // Make sure music loops automatically
        }

        // Update the slider's value to match the new instance's volume
        UpdateMusicVolumeSlider();
        UpdateSoundVolumeSlider();
    }

    private void UpdateMusicVolumeSlider()
    {
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = musicSource.volume;
        }
    }
    private void UpdateSoundVolumeSlider()
    {
        if (soundVolumeSlider != null)
        {
            soundVolumeSlider.value = soundSource.volume;
        }
    }

    public void PlaySound(string soundName)
    {
        for (int i = 0; i < soundNames.Length; i++)
        {
            if (soundNames[i] == soundName)
            {
                soundSource.PlayOneShot(sounds[i]);
                return;
            }
        }
        Debug.LogWarning("Sound named " + soundName + " not found!");
    }

    public void PlayMusic(string musicName)
    {
        for (int i = 0; i < musicNames.Length; i++)
        {
            if (musicNames[i] == musicName)
            {
                if (musicSource.isPlaying)
                    musicSource.Stop();
                musicSource.clip = musicTracks[i];
                musicSource.Play();
                return;
            }
        }
        Debug.LogWarning("Music track named " + musicName + " not found!");
    }

    public void PauseMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }

    public void ResumeMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.UnPause();
        }
    }

    public void SetSoundVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        soundSource.volume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        musicSource.volume = volume;
        // Update the slider value when the volume changes
        UpdateMusicVolumeSlider();
    }
}
