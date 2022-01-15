using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static readonly string SoundsPref = "SoundsPref";
	private static readonly string MusicPref = "MusicPref";
	private static readonly string MenuMusicPref = "MenuMusicPref";
	public AudioSource soundsSource;
	public AudioSource musicSource;
	public AudioSource menuMusicSource;
	private AudioClip buttonSound;

	public static AudioManager Instance = null;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}

		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
		menuMusicSource.volume = PlayerPrefs.GetFloat(MenuMusicPref, 1.0f);
		musicSource.volume = PlayerPrefs.GetFloat(MusicPref, 1.0f);
		soundsSource.volume = PlayerPrefs.GetFloat(SoundsPref, 1.0f);
		buttonSound = Resources.Load<AudioClip>("ButtonSound");
		menuMusicSource.Play();
	}

    private void FixedUpdate()
    {
        
    }

    public void Play(AudioClip clip)
	{
		soundsSource.clip = clip;
		soundsSource.Play();
	}


	public void PlayMusic(AudioClip clip)
	{
		if (menuMusicSource.isPlaying)
		{
			menuMusicSource.Stop();
		}
		
		musicSource.clip = clip;
		musicSource.Play();
	}

	public void PlayMenuMusic()
	{
		if (!menuMusicSource.isPlaying)
		{
			musicSource.Stop();
			menuMusicSource.Play();		
		}
	}

	public void PlayButtonSound()
	{
		soundsSource.clip = buttonSound;
		soundsSource.Play();
	}

	public void UpdateMusicVolume(float value)
	{
		musicSource.volume = value;
		menuMusicSource.volume = value;
	}

	public void UpdateSoundsVolume(float value)
	{
		soundsSource.volume = value;
	}

	public void SaveSoundSettings()
    {
		PlayerPrefs.SetFloat(MenuMusicPref, menuMusicSource.volume);
		PlayerPrefs.SetFloat(MusicPref, musicSource.volume);
		PlayerPrefs.SetFloat(SoundsPref, soundsSource.volume);
	}

	public float GetMusicVolume()
    {
		return musicSource.volume;
    }

	public float GetSoundsVolume()
	{
		return soundsSource.volume;
	}

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
			SaveSoundSettings();
        }
    }

}
