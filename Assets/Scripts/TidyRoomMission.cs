using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class TidyRoomMission : Mission
{
    
    public List<PickableObject> objectsToTidyUp;
    public List<ObjectPlaceholder> tidyPlaces;
    List<PickableObject> objectsInScene;
    List<ObjectPlaceholder> objPlaces;

    public override event Action<IMission> OnMissionCompleted;

    void Start()
    {
        objectsInScene = (from p in FindObjectsOfType<PickableObject>() select p).ToList();
        objPlaces = (from p in FindObjectsOfType<ObjectPlaceholder>() select p).ToList();

        foreach(PickableObject i in objectsInScene)
        {
            if(i.tag == "ObjToTidy")
            {
                objectsToTidyUp.Add(i);
            }
        }
        foreach (ObjectPlaceholder i in objPlaces)
        {
            if (i.tag == "TidyPlace")
            {
                tidyPlaces.Add(i);
            }
        }

    }

    void Update()
    {
        foreach(ObjectPlaceholder i in tidyPlaces)
        {
            if(i.itemDropped == null)
            {
                continue;
            }
            var obj = i.itemDropped;
            var tidyObj = obj.GetComponent<PickableObject>();
            if(tidyObj.objIdx == i.objIdx)
            {
                i.objInCorrectPlace = true;
            }
        }

        if((from t in tidyPlaces where t.objInCorrectPlace select t).Count() == tidyPlaces.Count)
        {
            hasFinished = true;
            OnMissionCompleted(this);
        }
    }


    public override void Restart()
    {
        hasFinished = false;
        foreach(PickableObject p in objectsToTidyUp)
        {
            p.transform.position = p.initialPosition;
        }
    }
}
