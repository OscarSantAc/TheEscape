using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THE_AI : MonoBehaviour
{

    public int phase = 1;
    private int att=1;
    private bool isDead=false;
    private bool firstTimePhase4 = true;
    private bool hasAttacked;
    public GameObject player;
    public GameObject book1;
    public GameObject book2;
    public GameObject book3;
    public GameObject rune;
    public GameObject doorVar;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public Transform firePoint7;
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public GameObject laser5;
    public GameObject laser6;
    public GameObject laser7;
    public GameObject projectile;
    public GameObject stalker;
    public Animator animator;
    private float delay1 = 0;
    private float delay2 = 0;
    private float delay3 = 0;
    public float range;
    private float startTime1 = 2;
    private float startTime2 = 4;
    private float startTime3 = 7;
    private Transform finalFirePoint;
    private List<Transform> pointList = new List<Transform>();
    private List<GameObject> stalkers = new List<GameObject>();
    public Sprite openDoor;
    public GameObject power;
    public AudioSource deathAudio;
    public AudioSource flapAudio;
    public AudioSource fireAudio;
    public AudioSource laserAudio;

    // Start is called before the first frame update
    void Start()
    {
        pointList.Add(firePoint1);
        pointList.Add(firePoint2);
        pointList.Add(firePoint3);
        pointList.Add(firePoint4);
        pointList.Add(firePoint5);
        pointList.Add(firePoint6);
        pointList.Add(firePoint7);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (!flapAudio.isPlaying)
            {
                flapAudio.Play();
            }
            if (phase == 1)
            {
                attack1();
            }
            else if (phase == 2)
            {
                attack2();
            }
            else if (phase == 3)
            {
                attack3();
            }
            else if (phase == 4)
            {
                if (firstTimePhase4 && stalkers.Count != 0)
                {
                    foreach (GameObject x in stalkers)
                    {
                        x.SendMessage("death");
                        firstTimePhase4 = false;
                    }
                    stalkers.Clear();
                }
                if (hasAttacked)
                {
                    System.Random rnd = new System.Random();
                    att = rnd.Next(0, 100) % 3;
                    hasAttacked = false;
                }
                switch (att)
                {
                    case 0:
                        attack1();
                        break;
                    case 1:
                        attack2();
                        break;
                    case 2:
                        attack3();
                        break;
                }
            }
        }
    }

    private void deathHelper()
    {
        animator.SetTrigger("isDead");
        isDead = true;
        if (flapAudio.isPlaying)
        {
            flapAudio.Stop();
        }
        if (laserAudio.isPlaying)
        {
            laserAudio.Stop();
        }
        if (stalkers.Count != 0)
        {
            foreach (GameObject x in stalkers)
            {
                x.SendMessage("death");
                firstTimePhase4 = false;
            }
            stalkers.Clear();
        }
        deathAudio.Play();
        Invoke("death", 2);
    }

    private void death()
    {
        Instantiate(power, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    private void nextPhase(int x)
    {
        phase=x;
        switch (phase)
        {
            case 2:
                book1.SetActive(false);
                book2.SetActive(true);
                break;
            case 3:
                book2.SetActive(false);
                book3.SetActive(true);
                break;
            case 4:
                book3.SetActive(false);
                rune.SetActive(true);
                break;
            case 5:
                rune.SetActive(false);
                doorVar.gameObject.GetComponent<SpriteRenderer>().sprite = openDoor;
                doorVar.SendMessage("hasAKey");
                deathHelper();
                break;
        }
    }

    private void attack1()
    {
        float distMin = 0;
        foreach (Transform x in pointList)
        {
            float distancia = Vector2.Distance(x.position, player.transform.position);
            if (x == pointList[0])
            {
                distMin = distancia;
                finalFirePoint = x;
            }
            else if (distancia < distMin)
            {
                distMin = distancia;
                finalFirePoint = x;
            }
        }

        if (Vector2.Distance(finalFirePoint.position, player.transform.position) <= range)
        {
            if (delay1 <= 0)
            {
                Instantiate(projectile, finalFirePoint.position, Quaternion.identity);
                fireAudio.Play();
                delay1 = startTime1;
                if (phase == 4)
                {
                    hasAttacked = true;
                }
            }
            else
            {
                delay1 -= Time.deltaTime;
            }
        }
    }

    private void attack2()
    {
        if (delay2 <= 0)
        {
            Invoke("startAttacking", 4.5f);
            Invoke("stopAttacking", 6.5f);
            Invoke("laserSound", 1.3f);
            float distMin = 0;
            int laserIndex = 0;
            int loopControl = 0;
            foreach (Transform x in pointList)
            {
                float distancia = Vector2.Distance(x.position, player.transform.position);
                if (x == pointList[0])
                {
                    distMin = distancia;
                    finalFirePoint = x;
                }
                else if (distancia < distMin)
                {
                    distMin = distancia;
                    finalFirePoint = x;
                    laserIndex = loopControl;
                }
                loopControl++;
            }
            if (Vector2.Distance(transform.position, player.transform.position) <= range)
            {
                switch (laserIndex)
                {
                    case 0:
                        Instantiate(laser1, finalFirePoint.position, this.transform.rotation);
                        break;
                    case 1:
                        Instantiate(laser2, finalFirePoint.position, this.transform.rotation);
                        break;
                    case 2:
                        Instantiate(laser3, finalFirePoint.position, this.transform.rotation);
                        break;
                    case 3:
                        Instantiate(laser4, finalFirePoint.position, this.transform.rotation);
                        break;
                    case 4:
                        Instantiate(laser5, finalFirePoint.position, this.transform.rotation);
                        break;
                    case 5:
                        Instantiate(laser6, finalFirePoint.position, this.transform.rotation);
                        break;
                    case 6:
                        Instantiate(laser7, finalFirePoint.position, this.transform.rotation);
                        break;
                }
                delay2 = startTime2;
                if (phase == 4)
                {
                    hasAttacked = true;
                }
            }
        }
        else
        {
            delay2 -= Time.deltaTime;
        }
    }

    private void attack3()
    {
        float distMax = 0;
        foreach (Transform x in pointList)
        {
            float distancia = Vector2.Distance(x.position, player.transform.position);
            if (x == pointList[0])
            {
                distMax = distancia;
                finalFirePoint = x;
            }
            else if (distancia > distMax)
            {
                distMax = distancia;
                finalFirePoint = x;
            }
        }
        if (Vector2.Distance(finalFirePoint.position, player.transform.position) <= range)
        {
            if (delay3 <= 0)
            {
                if (!animator.GetBool("isAttacking"))
                {
                    animator.SetBool("isAttacking", true);
                }
                stalkers.Add(Instantiate(stalker, finalFirePoint.position, Quaternion.identity));
                delay3 = startTime3;
                if (phase == 4)
                {
                    hasAttacked = true;
                }
            }
            else
            {
                delay3 -= Time.deltaTime;
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

    private void stopAttacking()
    {
        animator.SetBool("isAttacking", false);
    }

    private void startAttacking()
    {
        animator.SetBool("isAttacking", true);
    }

    private void laserSound()
    { 
        laserAudio.Play();
    }
}
