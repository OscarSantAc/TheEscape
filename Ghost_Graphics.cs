using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Graphics : MonoBehaviour
{

    public GameObject player;
    public GameObject power;
    public Animator animator;
    private bool isDead=false;
    private bool frozen;
    bool lookingLeft = false;
    public float speed = 3;
    private Rigidbody2D rb2d;
    public AudioSource deathAudio;
    public AudioSource ghostAudio;
    private CapsuleCollider2D capsuleCollider;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        capsuleCollider = this.GetComponent<CapsuleCollider2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        frozen = GlobalVariables.getFrozenTime();
        if (frozen && ghostAudio.isPlaying)
        {
            ghostAudio.Stop();
        }
        if (!isDead && !frozen)
        {
            float dist = Vector2.Distance(player.transform.position, this.gameObject.transform.position);
            if (dist < 10)
            {
                animator.SetBool("isAttacking", true);
                if (!ghostAudio.isPlaying)
                {
                    ghostAudio.Play();
                }
                if (dist < 8)
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
                    Vector3 dir = (player.transform.position - rb2d.transform.position).normalized;
                    rb2d.MovePosition(rb2d.transform.position + dir * speed * Time.fixedDeltaTime);
                }
            }
            else
            {
                animator.SetBool("isAttacking", false);
                if (ghostAudio.isPlaying)
                {
                    ghostAudio.Stop();
                }
            }
        }
    }
    


    
        private void OnTriggerEnter2D(Collider2D collider)
        {
        bool attacking = player.GetComponent<Player>().isAttacking;
        if (attacking)
        {
            boxCollider.enabled = false;
            capsuleCollider.enabled = false;
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0;
            animator.SetBool("isDead", true);
            isDead = true;
            Invoke("death", 0.5f);
            if (ghostAudio.isPlaying)
            {
                ghostAudio.Stop();
            }
            deathAudio.Play();
        }
        }
    
        private void death()
    {
        Instantiate(power, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
