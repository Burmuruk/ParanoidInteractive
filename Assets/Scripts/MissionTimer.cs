using System;
using UnityEngine;

public class MissionTimer : Mission, IMissionTimer
{
    [SerializeField] protected float startTime;
    [SerializeField] protected float finishTime;

    public virtual void Disable()
    {
        throw new NotImplementedException();
    }

    public virtual void Enable()
    {
        throw new NotImplementedException();
    }

    public virtual float GetActivationTime() => startTime;

    public virtual float GetDeactivationTime() => finishTime;
}
