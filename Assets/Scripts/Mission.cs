using System;
using UnityEngine;

public class Mission : MonoBehaviour, IMission
{
    [SerializeField] protected int sanityValue;
    [SerializeField] protected new string name;
    protected bool hasFinished;
    protected bool isEnabled = false;

    public virtual event Action<IMission> OnMissionCompleted;

    public virtual int GetHash() => GetHashCode();

    public virtual string GetName() => name;

    public virtual int GetSanityValue() => sanityValue;

    public virtual bool HasFinished() => hasFinished;

    public virtual void Restart()
    {
        throw new NotImplementedException();
    }
}
