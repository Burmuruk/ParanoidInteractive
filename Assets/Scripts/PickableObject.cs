using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class PickableObject : MonoBehaviour, IInteractable
{

    public bool reverse, objectPicked = false;
    public int objIdx;
    public Vector3 initialPosition;

    private void Start()
    {
        initialPosition = this.transform.position;
    }

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
        if(player.objectPicked == null)
        {
            var placeHolders = FindObjectsOfType<ObjectPlaceholder>();
            for (int i = 0; i < placeHolders.Length; i++)
            {
                if (placeHolders[i].droppedItem == true)
                {
                    if (placeHolders[i].itemDropped == this.gameObject)
                    {
                        placeHolders[i].itemDropped = null;
                        placeHolders[i].droppedItem = false;
                    }
                }
            }

            var collider = GetComponent<Collider>();
            collider.enabled = false;
            this.transform.position = player.handTransform.position;
            player.objectPicked = this.gameObject;
            transform.parent = player.handTransform;
        }
        yield return null;
    }
}
