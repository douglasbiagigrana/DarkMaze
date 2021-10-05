using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int totalCollectable = 10;

    void Start()
    {
         SpawnCollectable();
    }

    void SpawnCollectable()
    {
        for (int i = 0; i < totalCollectable; i++)
        {
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
            Instantiate(ObjectToSpawn, rndPosWithin, transform.rotation);
        }
    }
}