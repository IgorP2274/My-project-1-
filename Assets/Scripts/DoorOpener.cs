using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private bool _isClosing = false;
    private bool _isOpening = false;
    private int _openStateHeihgt = 4;
    private int _closeStateHeihgt = 1;

    public void Catch()
    {
        StartCoroutine(MoveDoor(_closeStateHeihgt));
    }

    public void SetFree()
    {
        StartCoroutine(MoveDoor(_openStateHeihgt));
    }

    public IEnumerator MoveDoor(int target)
    {
        _targetPosition = new Vector3(0, target, 3);

        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
