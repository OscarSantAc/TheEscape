using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THE_Stalker : MonoBehaviour
{

    GameObject player;
    bool lookingLeft = false;
    public float speed=3;
    Collider2D collider;
    public AudioSource stalker;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collider = collider = this.GetComponent<Collider2D>();
    }
    void Update()
    {
        if (!stalker.isPlaying)
        {
            stalker.Play();
        }
        if (player.transform.position.x >= transform.position.x)
        {
            if (lookingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                lookingLeft = !lookingLeft;
            }
        }
        else
        {
            if (!lookingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                lookingLeft = !lookingLeft;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    private void deathHelp()
    {
        collider.enabled = false;
        if (stalker.isPlaying)
        {
            stalker.Stop();
        }
        Invoke("death", 0.5f);
        
    }

    private void death()
    {
        //Dropear objeto
        Destroy(this.gameObject);
    }
}
