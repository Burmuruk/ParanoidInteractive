using System;

public interface IMission
{
    event Action OnMissionCompleted;
    void ChangeDay();
}
