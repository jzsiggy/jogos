using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    private Slider volumeSlider;
    public TMP_Text volumeValueText;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        UpdateVolumeText();
    }

    private void UpdateVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
        AudioListener.volume = value;
        UpdateVolumeText();
    }

    private void UpdateVolumeText()
    {
        int percentage = Mathf.RoundToInt(volumeSlider.value * 100);
        volumeValueText.text = $"{percentage}%";
    }
}