using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour  // Inherit from MonoBehaviour
{
    public UIScript uiScript;  // This should be set in the Inspector

    // This function will be called when the button is clicked
    public void Next()
    {
        if (uiScript != null)
        {
            Debug.Log("Next button clicked!");
            uiScript.ChangeProgress();  // Call the function on UIScript
        }
        else
        {
            Debug.LogWarning("UIScript reference is missing in ButtonHandler!");
        }
    }
}
