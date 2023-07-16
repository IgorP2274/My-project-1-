using System.Collections;
using UnityEngine;

public class BuzzerSoundSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private float _volume;
    private float _volumeChangeSpeed;
    private float _endVolume;
    private float _maxVolume;
    private float _minVolume;

    public void BuzzerSoundOn()
    {
        audioSource.Play();
        BuzzerSound(_minVolume, _maxVolume);
    }

    public void BuzzerSoundOff()
        => BuzzerSound(_maxVolume, _minVolume);

    private void Start()
    {
        _endVolume = 0;
        _volume = 0;
        _volumeChangeSpeed = 0.1f;
        _maxVolume = 1;
        _minVolume = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private void BuzzerSound(float oldTarget, float newTarget)
    {
        if (_endVolume == oldTarget)
        {
            _endVolume = newTarget;
            StartCoroutine(SetSoundLevel());
        }
    }

    private IEnumerator SetSoundLevel() 
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
