using System.Collections;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private int _openStateHeihgt = 4;
    private int _closeStateHeihgt = 1;
    private Coroutine _close;
    private Coroutine _open;

    public void Catch()
    {
        _targetPosition = new Vector3(0, _closeStateHeihgt, 3);

        if (_open != null)
            StopCoroutine(_open);

        _close = StartCoroutine(MoveDoor());
    }

    public void SetFree()
    {
        _targetPosition = new Vector3(0, _openStateHeihgt, 3);

        if (_close != null)
            StopCoroutine(_close);

        _open = StartCoroutine(MoveDoor());
    }

    private IEnumerator MoveDoor()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
