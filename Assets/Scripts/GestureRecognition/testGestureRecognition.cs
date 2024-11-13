/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.XR.WSA.Input;

public class testGestureRecognition : MonoBehaviour
{
    private GestureRecognizer recognizer;
    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.Hold | GestureSettings.NavigationX | GestureSettings.NavigationY | GestureSettings.NavigationZ);
        
        recognizer.Tapped += GestureRecognizer_Tapped;
        recognizer.HoldStarted += GestureRecognizer_HoldStarted;
        recognizer.HoldCompleted += GestureRecognizer_HoldCompleted;
        recognizer.HoldCanceled += GestureRecognizer_HoldCanceled;
        recognizer.NavigationStarted += GestureRecognizer_NavigationStarted;
        recognizer.NavigationUpdated += GestureRecognizer_NavigationUpdated;
        recognizer.NavigationCompleted += GestureRecognizer_NavigationCompleted;
        recognizer.NavigationCanceled += GestureRecognizer_NavigationCanceled;

        recognizer.StartCapturingGestures();
    }

    void OnDestroy()
    {
            recognizer.Tapped -= GestureRecognizer_Tapped;
            recognizer.HoldStarted -= GestureRecognizer_HoldStarted;
            recognizer.HoldCompleted -= GestureRecognizer_HoldCompleted;
            recognizer.HoldCanceled -= GestureRecognizer_HoldCanceled;
            recognizer.NavigationStarted -= GestureRecognizer_NavigationStarted;
            recognizer.NavigationUpdated -= GestureRecognizer_NavigationUpdated;
            recognizer.NavigationCompleted -= GestureRecognizer_NavigationCompleted;
            recognizer.NavigationCanceled -= GestureRecognizer_NavigationCanceled;
            recognizer.StopCapturingGestures();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
*/