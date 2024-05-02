using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manecillas : MonoBehaviour
{
    [SerializeField] GameObject hourM;
    [SerializeField] GameObject minuteM;
    [SerializeField] TextMesh txtHour;

    private void LateUpdate()
    {

        if (!txtHour)
        {
            var hour = ((int)GameManager.time) * 360 /12;
            var minute = (hour <= 0 ? GameManager.time : GameManager.time % hour) * 360;
            hourM.transform.rotation = Quaternion.Euler(new Vector3(0, 0, hour));
            minuteM.transform.rotation = Quaternion.Euler(new Vector3(0, 0, minute)); 
        }
        else
        {
            var hour = ((int)GameManager.time);
            var minute = (hour <= 0 ? GameManager.time : GameManager.time % hour) * 60;
            txtHour.text = $"{GetTime(hour)}:{GetTime(minute).Substring(0,2)}";
        }
    }

    private string GetTime(float value) =>
        value switch
        {
            <= 0 => "00",
            < 10 => "0" + value,
            _ => value.ToString()
        };
}
