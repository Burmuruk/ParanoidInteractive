using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> missionsEditor = null;
    [SerializeField] private List<IMission> missions = new();
    private List<IMission> missionsDone = new();
    UIMission UIMission;

    PlayerManager playerManager;

    struct Mission
    {
        public readonly IMission mission;
        public readonly bool completed;
    }

    private void Awake()
    {
        var newMissions = from m in missionsEditor where m.GetComponent<IMission>() != null select m.GetComponent<IMission>();
        
        foreach (var m in newMissions)
        {
            missions.Add(m);
        }
    }

    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        UIMission = FindObjectOfType<UIMission>();

        UIMission.UpdateMissions(missions.ToArray());
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

        UIMission.UpdateMissions(missions.ToArray());
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
        RestartRandomMission();
    }

    private void ReportProgress(int value)
    {
        playerManager.BarSanidad(value);
    }

    private void RestartRandomMission()
    {
        if (playerManager.barStates != PlayerManager.BarStates.MasomenosMal
            && playerManager.barStates != PlayerManager.BarStates.Mal)
            return;

        var rand = UnityEngine.Random.Range(0, 3);

        if (rand != 1) return;

        int idx = missionsDone.Count > 1 ? UnityEngine.Random.Range(0, missionsDone.Count) : 0;

        if ((int)playerManager.barStates >= 3)
        {
            missionsDone[idx].Restart();
        }
    }
}
