using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(0, 0, -1 * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(0, 0, _speed * Time.deltaTime);
    }
}
