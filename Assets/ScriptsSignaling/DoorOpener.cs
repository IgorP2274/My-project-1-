using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private bool _isMoving = false;
    private int _openStateHeihgt = 4;
    private int _closeStateHeihgt = 1;

    public void Catch()
    {
        _targetPosition = new Vector3(0, _closeStateHeihgt, 3);
        StartCoroutine(MoveDoor());
    }

    public void SetFree()
    {
        _targetPosition = new Vector3(0, _openStateHeihgt, 3);
        StartCoroutine(MoveDoor());
    }

    public IEnumerator MoveDoor()
    {
        if (_isMoving == false) 
        {
            _isMoving = true;

            while (transform.position != _targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
                yield return null;
            }

            _isMoving = false;
        }
        
    }
}
