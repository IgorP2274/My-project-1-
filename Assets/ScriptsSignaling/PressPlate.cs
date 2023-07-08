using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PressPlate : MonoBehaviour
{

    [SerializeField] private UnityEvent _steppedOnPlate;
    [SerializeField] private UnityEvent _leftPlate;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _steppedOnPlate?.Invoke();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _leftPlate?.Invoke();
    }
}
