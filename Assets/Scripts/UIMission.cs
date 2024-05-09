using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

class UIMission : MonoBehaviour
{
    [SerializeField] Text txtMissions;

    List<IMission> missions;
    MissionManager missionManager;

    private void Awake()
    {
        missionManager = FindObjectOfType<MissionManager>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void UpdateMissions(IMission[] missions)
    {
        string missionText = "";

        foreach (var mission in missions)
        {
            missionText += mission.GetName();

            if ((mission as IMissionTimer) is var missionTime && missionTime != null)
            {
                var time = missionTime.GetActivationTime();
                var hour = (int)time;
                var minute = time % hour * 100;

                missionText += $"\t\t{hour}:{(minute == 0 ? "00" : minute )}";
            }

            missionText += "\n";
        }
        
        txtMissions.text = missionText;
    }
}
