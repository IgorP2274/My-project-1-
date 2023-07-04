using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class buzzerController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private bool _isSound;
    private float _volume;
    private float _volumeChangeSpeed;

    void Start()
    {
        _isSound = false;
        _volume = 0;
        _volumeChangeSpeed = 0.1f;
        audioSource = GetComponent<AudioSource>();
    }

    public void BuzzerSoundOn() 
    {
        if (!_isSound)
        {
            float endVolume = 1f;
            _isSound = !_isSound;
            audioSource.Play();
            StartCoroutine(SoundOn(endVolume));
        }
    }

    public void BuzzerSoundOff()
    {
        if (_isSound) 
        {
            float endVolume = 0.01f;
            _isSound = !_isSound;
            StartCoroutine(SoundOff(endVolume));
        }
    }

    public IEnumerator SoundOn(float expectedVolume) 
    {
        _volume = audioSource.volume;

        while (_volume != expectedVolume && _isSound)
        {
            _volume = Mathf.MoveTowards(_volume, expectedVolume, _volumeChangeSpeed * Time.deltaTime);
            audioSource.volume = _volume;
            yield return null;
        }
    }

    public IEnumerator SoundOff(float expectedVolume)
    {
        _volume = audioSource.volume;

        while (_volume != expectedVolume && !_isSound)
        {
            _volume = Mathf.MoveTowards(_volume, expectedVolume, _volumeChangeSpeed * Time.deltaTime);
            audioSource.volume = _volume;
            yield return null;
        }

        if (_volume == 0)
            audioSource.Stop();
    }
}
