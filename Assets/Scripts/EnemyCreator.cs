using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject Enemy;
    public int RespawnTime;
    public int RespawnDelay;
    private bool isInactive;
    private int _highOfRespawn;

    private void Start()
    {
        isInactive = true;
        _highOfRespawn = 1;
    }

    public void StartCreation()
    {
        if (isInactive)
            StartCoroutine(Create());

        isInactive = false;
    }

    public IEnumerator Create()
    {
        yield return new WaitForSeconds(RespawnDelay);

        while (true)
        {
            Vector3 vector3 = transform.position + new Vector3(0, _highOfRespawn, 0);
            GameObject newOblect = Instantiate(Enemy, vector3, Quaternion.identity);
            yield return new WaitForSeconds(RespawnTime);
        }
    }
}
