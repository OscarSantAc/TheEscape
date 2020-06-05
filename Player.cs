using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField] float      m_speed = 1.0f;
    [SerializeField] float      m_jumpForce = 2.0f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;
    public bool isAttacking = false;
    public Animator animator;
    public static bool click;
    private static int power;
    private float dashSpeed = 50;
    private float dashTime;
    private float startDashTime= 0.5f;
    private int direction=0;
    private float timeStamp;
    private float cooldown = 1;
    private bool doubleJump = false;
    private bool firstTime = true;
    public AudioSource timeFreezeAudio;
    public AudioSource dashAudio;
    public AudioSource slashAudio;
    public AudioSource glideAudio;
    public AudioSource doubleJumpAudio;
    public AudioSource deathAudio;
    public AudioSource footsteps;
    public GameObject timer;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        GetComponent<SpriteRenderer>().flipX = true;
        click = GlobalVariables.getClick();
        dashTime = startDashTime;
        timeStamp = Time.time + cooldown;
        power = GlobalVariables.getPower();
    }
	
	// Update is called once per frame
	void Update () {
        if (!m_isDead)
        {
            //Check if character just landed on the ground
            if (!m_grounded && m_groundSensor.State())
            {
                m_grounded = true;
                m_animator.SetBool("Grounded", m_grounded);
            }

            //Check if character just started falling
            if (m_grounded && !m_groundSensor.State())
            {
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
            }

            // -- Handle input and movement --
            float inputX = Input.GetAxis("Horizontal");

            // Swap direction of sprite depending on walk direction
            if (inputX > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (inputX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            // Move
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

            //Set AirSpeed in animator
            m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);


            if(m_grounded && inputX != 0)
            {
                if (!footsteps.isPlaying)
                {
                    footsteps.Play();
                }
            }
            else
            {
                if (footsteps.isPlaying)
                {
                    footsteps.Stop();
                }
            }
            // -- Handle Animations --

            //Attack
            if (click)
            {
                if (power == 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (timeStamp <= Time.time)
                        {
                            m_animator.SetTrigger("Attack");
                            isAttacking = true;
                            Invoke("stopAttacking", 1f);
                            timeStamp = Time.time + cooldown;
                            slashAudio.Play();
                        }
                    }
                }
                else if (power == 1)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (timeStamp <= Time.time)
                        {
                            m_speed = 40f;
                            m_animator.SetTrigger("Dash");
                            isAttacking = true;
                            Invoke("stopAttacking", 0.2f);
                            timeStamp = Time.time + cooldown;
                            dashAudio.Play();
                        }
                    }
                }
                else if (power == 2)
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (timeStamp <= Time.time)
                        {
                            if (!m_grounded)
                            {
                                m_body2d.velocity = new Vector2(m_body2d.velocity.x, 0);
                                m_speed = 10f;
                                m_body2d.gravityScale = 12f;
                                m_animator.SetTrigger("Dash");
                                isAttacking = true;
                                if (!glideAudio.isPlaying)
                                {
                                    glideAudio.Play();
                                }
                            }
                            else
                            {
                                m_animator.SetTrigger("Attack");
                                isAttacking = true;
                                Invoke("stopAttacking", 1f);
                                timeStamp = Time.time + cooldown;
                                slashAudio.Play();
                            }
                        }
                    }
                    if (m_grounded)
                    {
                        glideAudio.Stop();
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        stopAttacking();
                        timeStamp = Time.time + cooldown;
                        glideAudio.Stop();
                    }
                }
                else if (power == 3)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (timeStamp <= Time.time)
                        {
                            m_animator.SetTrigger("Attack");
                            isAttacking = true;
                            Invoke("stopAttacking", 1f);
                            timeStamp = Time.time + cooldown;
                            slashAudio.Play();
                        }
                    }
                }
                else if(power == 4)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (timeStamp <= Time.time)
                        {
                            if (firstTime)
                            {
                                GlobalVariables.setFrozenTime(true);
                                Invoke("unfreezeTime", 2.3f);
                                firstTime = false;
                                timeStamp = 0;
                                timeFreezeAudio.Play();
                            }
                            else
                            {
                                m_animator.SetTrigger("Attack");
                                isAttacking = true;
                                Invoke("stopAttacking", 1f);
                                timeStamp = Time.time + cooldown;
                                slashAudio.Play();
                            }
                        }
                    }

                }
            }
            else
            {
                if (power == 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (timeStamp <= Time.time)
                        {
                            m_animator.SetTrigger("Attack");
                            isAttacking = true;
                            Invoke("stopAttacking", 1f);
                            timeStamp = Time.time + cooldown;
                            slashAudio.Play();
                        }
                    }
                }
                else if (power == 1)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (timeStamp <= Time.time)
                        {
                            m_speed = 40f;
                            m_animator.SetTrigger("Dash");
                            isAttacking = true;
                            Invoke("stopAttacking", 0.2f);
                            timeStamp = Time.time + cooldown;
                            dashAudio.Play();
                        }
                    }
                }
                else if (power == 2)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        if (timeStamp <= Time.time)
                        {
                            if (!m_grounded)
                            {
                                m_body2d.velocity = new Vector2(m_body2d.velocity.x, 0);
                                m_speed = 10f;
                                m_body2d.gravityScale = 12f;
                                m_animator.SetTrigger("Dash");
                                isAttacking = true;
                                if (!glideAudio.isPlaying)
                                {
                                    glideAudio.Play();
                                }
                            }
                            else
                            {
                                m_animator.SetTrigger("Attack");
                                isAttacking = true;
                                Invoke("stopAttacking", 1f);
                                timeStamp = Time.time + cooldown;
                                slashAudio.Play();
                            }
                        }
                    }
                    if (m_grounded)
                    {
                        glideAudio.Stop();
                    }
                    else if (Input.GetKeyUp(KeyCode.Space))
                    {
                        stopAttacking();
                        timeStamp = Time.time + cooldown;
                        glideAudio.Stop();
                    }
                }
                else if (power == 3)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (timeStamp <= Time.time)
                        {
                            m_animator.SetTrigger("Attack");
                            isAttacking = true;
                            Invoke("stopAttacking", 1f);
                            timeStamp = Time.time + cooldown;
                            slashAudio.Play();
                        }
                    }
                }
                else if (power == 4)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (timeStamp <= Time.time)
                        {
                            if (firstTime)
                            {
                                GlobalVariables.setFrozenTime(true);
                                Invoke("unfreezeTime", 2.3f);
                                firstTime = false;
                                timeStamp = 0;
                                timeFreezeAudio.Play();
                            }
                            else
                            {
                                m_animator.SetTrigger("Attack");
                                isAttacking = true;
                                Invoke("stopAttacking", 1f);
                                timeStamp = Time.time + cooldown;
                                slashAudio.Play();
                            }
                        }
                    }

                }
            }


            //Jump
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && (m_grounded || doubleJump))
            {
                if (power == 3 && !doubleJump)
                {
                    doubleJump = true;

                }else if (doubleJump)
                {
                    doubleJump = false;
                    doubleJumpAudio.Play();
                }
                m_animator.SetTrigger("Jump");
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                m_groundSensor.Disable(0.2f);
            }

            //Run
            else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            {
                m_animator.SetInteger("AnimState", 2);
            }

            //Idle
            else
            {
                m_animator.SetInteger("AnimState", 0);
            }


            if (m_grounded)
            {
                doubleJump = false;
            }
        }
    }

    void death()
    {
        Invoke("deathHelp", 2);
    }

    void deathHelp()
    {
        timer.SendMessage("saveTime", false);
        GlobalVariables.addDeath();
        System.String scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }

    bool checkAttacking()
    {
        return this.isAttacking;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!m_isDead)
        {
            bool attacking = isAttacking;
            if ((!attacking && collider.gameObject.tag != "Floor" && collider.gameObject.tag != "Item") || collider.gameObject.tag.Equals("Damage"))
            {
                if (!deathAudio.isPlaying)
                {
                    deathAudio.Play();
                }
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0;
                m_isDead = true;
                animator.SetBool("isDead", true);
                GlobalVariables.setFrozenTime(false);
                Invoke("death", 0.5f);
            }
        }
    }

    private void stopAttacking()
    {
        isAttacking = false;
        m_speed = 8f;
        m_body2d.gravityScale = 3f;
    }

    public static void setPower(int pow)
    {
        power = pow;
    }

    private void activateDoubleJump()
    {
        doubleJump = !doubleJump;
    }

    private void unfreezeTime()
    {
        GlobalVariables.setFrozenTime(false);
        firstTime = true;
        timeStamp = Time.time + 5;
    }

}
