using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPulseEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
    }

    public void OnPointerEnter(PointerEventData eventData)
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

    public void OnPointerExit(PointerEventData eventData)
    {
        isSelected = false;
        rectTransform.localScale = new Vector3(minScale, minScale, rectTransform.localScale.z);
        firstSelection = false;
    }
}