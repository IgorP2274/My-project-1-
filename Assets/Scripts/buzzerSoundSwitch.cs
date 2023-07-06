using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class buzzerSoundSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private bool _isSound;
    private float _volume;
    private float _volumeChangeSpeed;
    private float _endVolume;

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
            _endVolume = 1f;
            _isSound = true;
            audioSource.Play();
            StartCoroutine(SetSoundLevel());
        }
    }

    public void BuzzerSoundOff()
    {
        if (_isSound) 
        {
            _endVolume = 0f;
            _isSound = false;
            StartCoroutine(SetSoundLevel());
        }
    }

    public IEnumerator SetSoundLevel() 
    {
        _volume = audioSource.volume;

        while (_volume != _endVolume)
        {
            _volume = Mathf.MoveTowards(_volume, _endVolume, _volumeChangeSpeed * Time.deltaTime);
            audioSource.volume = _volume;
            yield return null;
        }

        if (!_isSound && _volume==0)
            audioSource.Stop();
    }
}
