using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Player", menuName = "Custom/Audio/Sound Player")]
public class SoundPlayer : ScriptableObject
{
    AudioSource source;

    public void PlayOneShot(SoundClip sound)
    {
        if (source != null)
        {
            source.PlayOneShot(sound.clip, sound.volume);
        }
    }

    public void SetSource(AudioSource _source)
    {
        source = _source;
    }

    public void RemoveSource()
    {
        if (source != null)
        {
            source = null;
        }
    }
}
