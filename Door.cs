using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool key=false;
    public AudioSource doorOpen;
    public GameObject timer;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (key)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            timer.SendMessage("saveTime", scene == 7);
            SceneManager.LoadScene(scene+1);
        }
    }

    public void hasAKey()
    {
        key = true;
        doorOpen.Play();
    }
}
