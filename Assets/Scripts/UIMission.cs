using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

    private void UpdateMissions()
    {
        foreach (var mission in missions)
        {
            txtMissions.text += mission.GetName();
        }
    }
}
