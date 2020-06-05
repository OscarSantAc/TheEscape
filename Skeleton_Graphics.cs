using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Graphics : MonoBehaviour
{
    public GameObject player;
    public GameObject power;
    public Animator animator;
    private bool isDead = false;
    private bool frozen;
    public AudioSource deathAudio;
    public AudioSource skeletonAudio;

    private void Update()
    {
        frozen = GlobalVariables.getFrozenTime();
        if (!skeletonAudio.isPlaying && !frozen && Vector2.Distance(transform.position, player.transform.position) <= 9)
        {
            skeletonAudio.Play();
        }else if((Vector2.Distance(transform.position, player.transform.position) > 9 || frozen) && skeletonAudio.isPlaying)
        {
            skeletonAudio.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isDead)
        {
            bool attacking = player.GetComponent<Player>().isAttacking;
            if (attacking)
            {
                animator.SetBool("isDead", true);
                isDead = true;
                if (skeletonAudio.isPlaying)
                {
                    skeletonAudio.Stop();
                }
                deathAudio.Play();
                Invoke("death", 0.5f);
            }
        }
    }

    private void death()
    {
        Instantiate(power, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }
}
