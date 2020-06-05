using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_AI : MonoBehaviour
{
    public Transform player;
    public GameObject power;
    public float range;
    private float delay;
    private float startTime;
    public GameObject projectile;
    private bool isDead = false;
    public Animator animator;
    public Transform firePoint;
    private bool lookingLeft = true;
    private bool frozen;
    public AudioSource deathAudio;
    public AudioSource castAudio;

    private void Start()
    {
        delay = 1;
        startTime = 3;
    }

    private void Update()
    {
        frozen = GlobalVariables.getFrozenTime();
        if (!frozen)
        {
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
            if (Vector2.Distance(transform.position, player.transform.position) <= range)
            {
                if (delay <= 0)
                {
                    if (!animator.GetBool("isAttacking"))
                    {
                        animator.SetBool("isAttacking", true);
                    }
                    Instantiate(projectile, firePoint.position, Quaternion.identity);
                    castAudio.Play();
                    delay = startTime;
                }
                else
                {
                    delay -= Time.deltaTime;
                }
            }
            else
            {
                if (animator.GetBool("isAttacking"))
                {
                    animator.SetBool("isAttacking", false);
                }
            }
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
                deathAudio.Play();
                Invoke("death", 0.5f);
            }
        }
    }

    private void death()
    {
        Instantiate(power, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
