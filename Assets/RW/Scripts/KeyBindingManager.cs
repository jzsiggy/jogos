using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class KeyBindingManager : MonoBehaviour
{
    public TextMeshProUGUI jumpKeyText;
    public TextMeshProUGUI moveUpKeyText;
    public TextMeshProUGUI moveDownKeyText;

    private string newKey;
    private TextMeshProUGUI currentKeyText;
    private bool waitingForKey = false;

    private void Start()
    {
        // Update the key binding texts to match the current key bindings
        jumpKeyText.text = PlayerPrefs.GetString("JumpKey", "Space");
        moveUpKeyText.text = PlayerPrefs.GetString("MoveUpKey", "W");
        moveDownKeyText.text = PlayerPrefs.GetString("MoveDownKey", "S");
    }

    public void ChangeKey(TextMeshProUGUI keyText)
    {
        if (!waitingForKey)
        {
            currentKeyText = keyText;
            waitingForKey = true;
        }
    }

    public void UpdateKeyTexts()
    {
        jumpKeyText.text = PlayerPrefs.GetString("JumpKey", "Space");
        moveUpKeyText.text = PlayerPrefs.GetString("MoveUpKey", "W");
        moveDownKeyText.text = PlayerPrefs.GetString("MoveDownKey", "S");
    }

    private void Update()
    {
        if (waitingForKey)
        {
            var keyboard = Keyboard.current;
            foreach (var key in keyboard.allKeys)
            {
                if (key.wasPressedThisFrame)
                {
                    newKey = key.ToString(); // Assign the key as a string
                    waitingForKey = false;

                    string action = currentKeyText.transform.parent.name;
                    PlayerPrefs.SetString(action + "Key", newKey);
                    PlayerPrefs.Save(); // Save the changes to PlayerPrefs
                    currentKeyText.text = newKey;
                    newKey = null; // Reset the newKey variable
                    
                    break;
                }
            }
        }
    }

    public Key KeyFromPrefs(string keyName, string defaultValue)
    {
        string savedValue = PlayerPrefs.GetString(keyName, defaultValue);
        Key result;
        if (Key.TryParse(savedValue, out result))
        {
            return result;
        }
        else
        {
            return Key.None;
        }
    }
}