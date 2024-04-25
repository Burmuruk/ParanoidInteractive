using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;


public class ItemPlace : MonoBehaviour, IInteractable
{
    public bool reverse, droppedItem = false;
    public bool imInteractive()
    {
        if (!droppedItem)
        {
            StartCoroutine(DropItem());
            droppedItem = true;
            return true;
        }
        return false;
    }

    IEnumerator DropItem()
    {
        var player = FindObjectOfType<SUPERCharacterAIO>();
        if (player.objectPicked != null)
        {
            var objToDrop = player.objectPicked;
            objToDrop.transform.position = this.transform.position;
            objToDrop.transform.parent = default;
            var collider = objToDrop.GetComponent<Collider>();
            collider.enabled = true;
        }
        yield return null;
    }
}
