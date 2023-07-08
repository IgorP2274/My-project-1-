using System.Collections;
using UnityEngine;

public class buzzerSoundSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private float _volume;
    private float _volumeChangeSpeed;
    private float _endVolume;

    void Start()
    {
        _endVolume = 0;
        _volume = 0;
        _volumeChangeSpeed = 0.1f;
        audioSource = GetComponent<AudioSource>();
    }

    public void BuzzerSoundOn() 
    {
        if (_endVolume == 0)
        {
            _endVolume = 1f;
            audioSource.Play();
            StartCoroutine(SetSoundLevel());
        }
    }

    public void BuzzerSoundOff()
    {
        if (_endVolume == 1) 
        {
            _endVolume = 0f;
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

        if (_endVolume == 0 && _volume==0)
            audioSource.Stop();
    }
}
