using System;

public interface IMission
{
    abstract event Action<IMission> OnMissionCompleted;
    void Restart();
    int GetSanityValue();
    bool HasFinished();
    int GetHash();
}

public interface IMissionTimer
{
    float GetActivationTime();
    float GetDeactivationTime();
    void Enable();
    void Disable();
}
