// Script criado para fazer com que os botões do menu principal pulsem quando o usuario passa o mouse em cima deles

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPulseEffect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public float minScale = 0.9f;
    public float maxScale = 1.1f;
    public float pulseSpeed = 1f;
    public AudioClip buttonNavigateClip;

    private RectTransform rectTransform;
    private float pulseDirection = 1f;
    private bool isSelected = false;
    private bool firstSelection = false;
    private bool sceneStarted = true;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isSelected)
        {
            float scaleFactor = 1f + pulseDirection * pulseSpeed * Time.deltaTime;
            float newScaleX = rectTransform.localScale.x * scaleFactor;
            float newScaleY = rectTransform.localScale.y * scaleFactor;

            if (newScaleX > maxScale || newScaleX < minScale)
            {
                pulseDirection *= -1f;
            }
            else
            {
                rectTransform.localScale = new Vector3(newScaleX, newScaleY, rectTransform.localScale.z);
            }
        }

        if (sceneStarted && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)))
        {
            sceneStarted = false;
        }
    }

    public void OnSelect(BaseEventData eventData)
    { 
        isSelected = true;
        rectTransform.localScale = new Vector3(maxScale, maxScale, rectTransform.localScale.z);

        if (!firstSelection && !sceneStarted)
        {
            AudioManager.Instance.PlaySFX(buttonNavigateClip);
        }
        else
        {
            firstSelection = false;
            sceneStarted = false;
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
        rectTransform.localScale = new Vector3(minScale, minScale, rectTransform.localScale.z);
        firstSelection = false;
    }
}