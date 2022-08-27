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
        currTimePt++;
        currDirector.time = timePoints[currTimePt];
            
        if (timePoints[currTimePt] > timePoints.Length) currTimePt = timePoints.Length-1;   
    }

    public void BackwardTimePoint()
    {
        currTimePt--;
        currDirector.time = timePoints[currTimePt];
        
        if (timePoints[currTimePt] < 0) currTimePt = 0;
    }

    public void LoopSequence (float timeToResetTo)
    {
        currDirector.time = timeToResetTo;
    }
}
