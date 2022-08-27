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
        print(timePoints.Length);
        currTimePt++;
        if (currTimePt >= timePoints.Length) currTimePt = timePoints.Length-1; 

        currDirector.time = timePoints[currTimePt];
    }

    public void BackwardTimePoint()
    {
        currTimePt--;
        if (currTimePt < 0) currTimePt = 0;

        currDirector.time = timePoints[currTimePt];
        
    }

    public void LoopSequence (float timeToResetTo)
    {
        currDirector.time = timeToResetTo;
    }
}
