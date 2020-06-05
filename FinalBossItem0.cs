using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossItem0 : MonoBehaviour
{
    private GameObject THE;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        THE = GameObject.FindGameObjectWithTag("Boss");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            THE.SendMessage("nextPhase", 2);
        }
    }
}
