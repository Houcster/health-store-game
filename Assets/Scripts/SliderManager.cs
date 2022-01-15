using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
	private AudioManager audioManager;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        musicSlider.value = audioManager.GetMusicVolume();
        soundsSlider.value = audioManager.GetSoundsVolume();    
    }

    public void ChangeMusic(float value)
    {
        audioManager.UpdateMusicVolume(value);
    }

    public void ChangeSounds(float value)
    {
        audioManager.UpdateSoundsVolume(value);
    }
}
