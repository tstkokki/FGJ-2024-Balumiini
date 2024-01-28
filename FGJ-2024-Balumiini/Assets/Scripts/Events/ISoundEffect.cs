using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundEffect
{
    public SoundPlayer Player { get; }
    public SoundClip Effect { get; }

    void PlayEffect();
}
