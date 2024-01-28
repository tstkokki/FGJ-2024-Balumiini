using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueEffects : MonoBehaviour
{
    public ParticleSystem Swish;
    public ParticleSystem Swoosh;

    public void PlaySwish()
    {
        Swish.Clear();
        Swish.Stop();
        Swish.Play();
    }

    public void PlaySwoosh()
    {
        Swoosh.Play();
    }

}
