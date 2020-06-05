using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject doorVar;
    public Sprite openDoor;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        doorVar.gameObject.GetComponent<SpriteRenderer>().sprite = openDoor;
        doorVar.SendMessage("hasAKey");
        Destroy(this.gameObject);
    }

}
