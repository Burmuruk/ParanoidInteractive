using System;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjSpawner : MonoBehaviour
{
    [SerializeField] List<GameManager> persistentObjectsPref;

    static bool hasSpawned = false;

    private void Awake()
    {
        if (hasSpawned) return;

        SpawnObjects();

        hasSpawned = true;
    }

    private void SpawnObjects()
    {
        foreach (var obj in persistentObjectsPref)
        {
            var newObj = Instantiate(obj);
            DontDestroyOnLoad(newObj);
        }
    }
}
