using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
public class CookMission : MissionSequence
{
    public List<PickableObject> objectsToCook;
    public ObjectPlaceholder stove;
    List<PickableObject> objectsInScene;

    void Start()
    {
        objectsInScene = (from p in FindObjectsOfType<PickableObject>() select p).ToList();
        foreach (PickableObject i in objectsInScene)
        {
            if (i.tag == "ObjToCook")
            {
                objectsToCook.Add(i);
            }
        }
    }
    void Update()
    {

    }


}
