using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class PickableObject : MonoBehaviour, IInteractable
{

    public bool reverse, objectPicked = false;
    public bool imInteractive()
    {
        if (!objectPicked)
        {
            StartCoroutine(PickObject());
            objectPicked = true;
            return true;
        }
        return false;
    }

    IEnumerator PickObject()
    {
        var player = FindObjectOfType<SUPERCharacterAIO>();
        this.transform.position = player.handTransform.position;
        player.objectPicked = this.gameObject;
        transform.parent = player.handTransform;
        yield return null;
    }
}
