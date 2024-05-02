using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionSequence : MonoBehaviour, IMission
{
    [SerializeField] List<IMission> missions = new List<IMission>();
    int current;

    public virtual event Action<IMission> OnMissionCompleted;

    private void Start()
    {
        missions.ForEach(mission => { mission.OnMissionCompleted += DisableMission; });
    }

    private void DisableMission(IMission mission)
    {
        current++;
    }

    public int GetHash()
    {
        return missions[current].GetHash();
    }

    public int GetSanityValue()
    {
        return missions[current].GetSanityValue();
    }

    public bool HasFinished()
    {
        return current >= missions.Count;
    }

    public void Restart()
    {
        if (current >= missions.Count) --current;

        for (int i = current; i > 0; i--)
        {
            missions[i].Restart();
        }

        current = 0;
    }

    public string GetName()
    {
        return missions[current].GetName();
    }
}
