using UnityEngine;
using UnityEngine.XR;
using MixedReality.Toolkit;
using System.Collections.Generic;

public class GestureRecognizer : MonoBehaviour
{       
    private UIScript  UIScript;
    private Vector3 startHandPosition;
    private Vector3 endHandPosition;
    private bool isSwiping = false;
    private const float swipeThreshold = 0.1f;

    void Update()
    {
        // Detect hand tracking input using MRTK3's Interaction SDK
        if (TryGetHandPosition(Handedness.Right, out Vector3 handPosition))
        {
            DetectSwipeGesture(handPosition);
        }
    }

    private void DetectSwipeGesture(Vector3 currentPosition)
    {
        if (!isSwiping)
        {
            startHandPosition = currentPosition;
            isSwiping = true;
        }
        else
        {
            endHandPosition = currentPosition;
            HandleSwipe();
            isSwiping = false;
        }
    }

    private void HandleSwipe()
    {
        Vector3 swipeDirection = endHandPosition - startHandPosition;

        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            if (swipeDirection.x > swipeThreshold)
            {
                OnSwipeRight();
            }
            else if (swipeDirection.x < -swipeThreshold)
            {
                OnSwipeLeft();
            }
        }
        else
        {
            if (swipeDirection.y > swipeThreshold)
            {
                OnSwipeUp();
            }
            else if (swipeDirection.y < -swipeThreshold)
            {
                OnSwipeDown();
            }
        }
    }

    private void OnSwipeRight() => UIScript.ChangeProgress();
    private void OnSwipeLeft() => Debug.Log("Swipe Left detected!");
    private void OnSwipeUp() => Debug.Log("Swipe Up detected!");
    private void OnSwipeDown() => Debug.Log("Swipe Down detected!");

    private bool TryGetHandPosition(Handedness handedness, out Vector3 handPosition)
    {
        // Using XR Hand Tracking for MRTK3
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HandTracking, inputDevices);

        foreach (var device in inputDevices)
        {
            if (device.TryGetFeatureValue(CommonUsages.devicePosition, out handPosition))
            {
                return true;
            }
        }

        handPosition = Vector3.zero;
        return false;
    }
}
