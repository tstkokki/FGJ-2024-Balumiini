using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceInjector : MonoBehaviour
{
    [SerializeField]
    SoundPlayer player;


    private void OnEnable()
    {
        AudioSource source = GetComponent<AudioSource>();
        player.SetSource(source);
    }

    private void OnDisable()
    {
        player.RemoveSource();
    }

}
