using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THE_Laser : MonoBehaviour
{
    Collider2D collider;
    private void Start()
    {
        collider = this.GetComponent<Collider2D>();
        Invoke("activateDamage", 1.5f);
    }

    void activateDamage()
    {
        collider.enabled = true;
        Invoke("deactivateDamage", 1.5f);
    }

    void deactivateDamage()
    {
        collider.enabled = false;
        Invoke("death", 0.67f);
    }

    void death()
    {
        Destroy(transform.parent.gameObject);
    }
}
