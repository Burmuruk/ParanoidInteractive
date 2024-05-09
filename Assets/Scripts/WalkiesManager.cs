using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WalkiesManager : MonoBehaviour
{
    [SerializeField] WalkieBodie[] bodies;
    [SerializeField] WalkieFace[] faces;
    [SerializeField] int sanity = 0;
    List<Walkie> activeWalkies = new List<Walkie>();
    [SerializeField] GameObject[] spawnPoints;

    [Serializable]
    record WalkieBodie
    {
        public GameObject body;
        public Transform facePlace;
    }

    [Serializable]
    record WalkieFace
    {
        public GameObject face;
        public int sanity;
        public string[] dialogs;
    }

    [Serializable]
    struct SpawnData
    {
        public readonly GameObject spawnPoint;

        public int Uses { get; private set; }

        public SpawnData(GameObject spawnPoint)
        {
            this.spawnPoint = spawnPoint;
            Uses = 0;
        }
    }

    private void Start()
    {
        ShowWalkie();
    }

    public void SetSanity(int sanity) => this.sanity = sanity;

    public void ShowWalkie()
    {
        Transform spawnPoint = GetSpawnPoint();
        int bodyId = UnityEngine.Random.Range(0, bodies.Length);

        var body = Instantiate(bodies[bodyId].body, spawnPoint);
        var face = (from f in faces where f.sanity == sanity select f).First();
        var inst = Instantiate(face.face, bodies[bodyId].facePlace.position, Quaternion.identity, body.transform);
        body.transform.localPosition = Vector3.zero;
        inst.transform.localPosition = Vector3.zero;

        var walkieCmp = body.AddComponent<Walkie>();
        walkieCmp.SetDialog(face.dialogs[UnityEngine.Random.Range(0, face.dialogs.Length)]);
        activeWalkies.Add(walkieCmp);
    }

    private Transform GetSpawnPoint()
    {
        var rand = UnityEngine.Random.Range(0, spawnPoints.Length);
        return spawnPoints[rand].transform;
    }

    public List<Walkie> GetActiveWalkies() { return activeWalkies; }
}

