using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _targetPosition;

    public void Catch()
       => StartCoroutine(Close());

    public void SetFree()
       => StartCoroutine(Open());

    public IEnumerator Close()
    {
        _targetPosition = new Vector3(0,1,3);

        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator Open()
    {
        _targetPosition = new Vector3(0, 4, 3);

        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
