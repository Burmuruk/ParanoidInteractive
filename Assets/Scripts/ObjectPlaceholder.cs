using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;


public class ObjectPlaceholder : MonoBehaviour, IInteractable
{
    public bool reverse, droppedItem = false;
    public GameObject itemDropped = null;
    public int objIdx;
    public bool objInCorrectPlace;

    void Update()
    {
        if(itemDropped == null)
        {
            objInCorrectPlace = false;
        }
    }

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
            itemDropped = player.objectPicked;
            player.objectPicked = null;
            itemDropped.transform.position = this.transform.position;
            itemDropped.transform.parent = default;
            var objCollider = itemDropped.GetComponent<Collider>();
            objCollider.enabled = true;
            var obj = itemDropped.GetComponent<PickableObject>();
            obj.objectPicked = false;
        }
        yield return null;
    }
}
