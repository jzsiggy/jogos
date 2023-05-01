using UnityEngine;
using UnityEngine.UI;

public class FullscreenControl : MonoBehaviour
{
    public Toggle fullscreenToggle;

    void Start(){
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
}