using SUPERCharacter;
using System;
using UnityEngine;

public class Walkie : MonoBehaviour, IInteractable
{
    public string dialog;
    public bool hasSpeak;
    
    public event Action<string> OnSpeak;

    public string Dialog { get { return dialog; } }
    public bool HasSpeak { get { return hasSpeak; } }

    public void SetDialog(string dialog)
    {
        this.dialog = dialog;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            imInteractive();
        }
    }

    public bool imInteractive()
    {
        OnSpeak?.Invoke(dialog); print(dialog);
        hasSpeak = true;
        return hasSpeak;
    }

    private void OnBecameInvisible()
    {
        if (hasSpeak)
        {
            KillWalkie();
        }
    }

    public void KillWalkie()
    {
        Destroy(gameObject);
    }
}