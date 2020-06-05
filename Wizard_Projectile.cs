using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Projectile : MonoBehaviour
{

    private float speed=3f;
    private Transform player;
    private Vector2 target;
    private bool isDead;
    public Animator animator;
    private Collider2D collider;
    private bool frozen;
    public AudioSource fireAudio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        collider = this.GetComponent<Collider2D>();
        fireAudio.Play();
    }
    
    void Update()
    {
        frozen = GlobalVariables.getFrozenTime();
        if (!isDead && !frozen)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                animator.SetBool("isDead", true);
                isDead = true;
                Invoke("death", 0.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!isDead)
        {
            if (coll.gameObject.tag!="Player")
            {
                Invoke("death", 0.5f);
                collider.enabled = false;
                animator.SetBool("isDead", true);
                isDead = true;
            }
        }
    }

    private void death()
    {
        Destroy(this.gameObject);
    }
}
