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

    public void Catch() =>
        GetDoorState(_closeStateHeihgt, _open, _close);

    public void SetFree() =>
        GetDoorState(_openStateHeihgt, _close, _open);

    private IEnumerator MoveDoor()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }

    public void GetDoorState(int stateHeihgt, Coroutine end, Coroutine start)
    {
        _targetPosition = new Vector3(0, stateHeihgt, 3);

        if (end != null)
            StopCoroutine(end);

        start = StartCoroutine(MoveDoor());
    }
}
