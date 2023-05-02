using UnityEngine;
using TMPro;

public class GraphicsQualityChanger : MonoBehaviour
{
    public TMP_Dropdown qualityDropdown;

    private void Start()
    {
        int qualityLevel = PlayerPrefs.GetInt("QualityLevel", 0);
        qualityDropdown.value = qualityLevel;
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetGraphicsQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
        PlayerPrefs.SetInt("QualityLevel", qualityLevel);
        PlayerPrefs.Save();
    }
}