using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    //Nothing is used so far
    public static event Action InPickUpRange;
    public static event Action LeftPickUpRange;

    public static void ActivatePickupFeedback()
    {
        InPickUpRange?.Invoke();
    }
    public static void DeactivatePickupFeedback()
    {
        LeftPickUpRange?.Invoke();        
    }
}