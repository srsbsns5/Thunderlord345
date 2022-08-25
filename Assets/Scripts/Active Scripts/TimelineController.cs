using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public float[] timePoints;
    [SerializeField] int currTimePt;
    public PlayableDirector currDirector;

    public void ForwardTimePoint()
    {
        for (int i = 0; i < timePoints.Length; i++)
        {
            i++;
            currDirector.time = timePoints[i];
            
            currTimePt = i;
            if (timePoints[i] > timePoints.Length) return;
            
        }

    }

    public void BackwardTimePoint()
    {
        for (int i = 0; i < timePoints.Length; i++)
        {
            i--;
            currDirector.time = timePoints[i];
            
            currTimePt = i;
            
            if (timePoints[i] < 0) return;
        }
    }

    public void LoopSequence (float timeToResetTo)
    {
        currDirector.time = timeToResetTo;
    }
}
