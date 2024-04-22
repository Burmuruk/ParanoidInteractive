using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<IMission> missions = new();
    private List<IMission> missionsDone = new();

    PlayerManager playerManager;

    struct Mission
    {
        public readonly IMission mission;
        public readonly bool completed;
    }

    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void OnEnable()
    {
        missions.ForEach(m => { m.OnMissionCompleted += DisableMission; });
    }

    private void OnDisable()
    {
        missions.ForEach(m => { m.OnMissionCompleted -= DisableMission; });
    }

    public void ChangeDay()
    {
        while (missionsDone.Count > 0)
        {
            if (missions[0].HasFinished())
            {
                missions.Add(missionsDone[0]);
                missionsDone[0].Restart();

                missionsDone.RemoveAt(0); 
            }
        }
    }

    private void DisableMission(IMission mission)
    {
        for (int i = 0; i < missions.Count; i++)
        {
            if (mission.GetHash() == missions[i].GetHash())
            {
                if (mission.HasFinished())
                {
                    missionsDone.Add(mission);
                    missions.Remove(mission);
                }
            }
        }

        ReportProgress(mission.GetSanityValue());
    }

    private void ReportProgress(int value)
    {
        playerManager.BarSanidadMas(value);
    }
}
