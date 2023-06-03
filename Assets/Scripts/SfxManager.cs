using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceAudio;
    [SerializeField] private AudioClip _sfxGame;
    public void PlayEffect()
    {
        _sourceAudio.clip = _sfxGame;
        _sourceAudio.Play();
    }
}
