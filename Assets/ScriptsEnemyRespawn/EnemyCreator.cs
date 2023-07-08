using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _respawnTime;
    [SerializeField] private int _respawnDelay;
    private bool _isInactive;
    private int _highOfRespawn;

    private void Start()
    {
        _isInactive = true;
        _highOfRespawn = 1;
    }

    public void StartCreation()
    {
        if (_isInactive)
            StartCoroutine(Create());

        _isInactive = false;
    }

    public IEnumerator Create()
    {
        yield return new WaitForSeconds(_respawnDelay);

        while (true)
        {
            Vector3 vector3 = transform.position + new Vector3(0, _highOfRespawn, 0);
            Instantiate(_enemy, vector3, Quaternion.identity);
            yield return new WaitForSeconds(_respawnTime);
        }
    }
}
