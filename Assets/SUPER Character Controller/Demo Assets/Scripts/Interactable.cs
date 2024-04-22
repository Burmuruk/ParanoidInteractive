using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SUPERCharacter;

[RequireComponent(typeof(Collider))]
public class Interactable : PlayerManager, IInteractable
{
    public UnityEvent OnInteract;

    public bool imInteractive(){
        OnInteract.Invoke();
        return true;
    }

    public void DestroySelf(){
        Destroy(gameObject);
    }
}
