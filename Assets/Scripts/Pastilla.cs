using SUPERCharacter;
using System;
using UnityEngine;

public class Pastilla : MonoBehaviour, ICollectable, IMission, IInteractable, IMissionTimer
{
    [SerializeField] int sanityValue;
    [SerializeField] float activitionTime;
    [SerializeField] float deactivitionTime;
    bool hasFinished;
    bool isEnabled = false;

    public event Action<IMission> OnMissionCompleted;

    private void Update()
    {
        if (!isEnabled && GameManager.timer >= GetActivationTime()
            && GameManager.timer < GetDeactivationTime())
        {
            Enable();
        }
        else if (isEnabled && GameManager.timer >= GetDeactivationTime())
        {
            Disable();
        }
    }

    public void Collect()
    {
        throw new NotImplementedException();
    }

    public void Disable()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        isEnabled = false;
    }

    public void Enable()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        isEnabled = true;
    }

    public float GetActivationTime()
    {
        return activitionTime;
    }

    public float GetDeactivationTime()
    {
        return deactivitionTime;
    }

    public int GetHash()
    {
        return GetHashCode();
    }

    public int GetSanityValue()
    {
        return sanityValue;
    }

    public bool HasFinished()
    {
        return hasFinished;
    }

    public bool imInteractive()
    {
        Invoke("Disable", .2f);
        hasFinished = true;

        OnMissionCompleted?.Invoke(this);
        return true;
    }

    public void Restart()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        hasFinished = false;
    }
}
