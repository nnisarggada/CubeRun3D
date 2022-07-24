using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControls : MonoBehaviour
{
	private void Start()
	{
		audioMixer.GetFloat("volume", out float slidervalue);
		slider.value = slidervalue;
	}
	public AudioMixer audioMixer;
	public Slider slider;
    public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
		audioMixer.GetFloat("volume", out float slidervalue);
		slider.value = slidervalue;
	}
}
