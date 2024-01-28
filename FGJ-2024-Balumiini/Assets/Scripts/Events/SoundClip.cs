using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Clip", menuName = "Custom/Audio/Sound Clip")]
public class SoundClip : ScriptableObject
{
    public AudioClip clip;

    public float volume = 1;
}
