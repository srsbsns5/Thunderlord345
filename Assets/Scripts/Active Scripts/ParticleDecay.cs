using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecay : MonoBehaviour
{
    public float decayTime;
    void OnEnable()
    {
        Destroy(gameObject, decayTime);
    }
}
