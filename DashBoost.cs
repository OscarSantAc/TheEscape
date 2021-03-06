﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBoost : MonoBehaviour
{
    private Transform player;
    private Collider2D collider;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        collider = this.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!isDead)
        {
            if (coll.gameObject.tag == "Player")
            {
                collider.enabled = false;
                isDead = true;
                Player.setPower(1);
                GlobalVariables.setPower(1);
                Destroy(this.gameObject);

            }
        }
    }
    
}
