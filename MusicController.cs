using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{

    public AudioSource menuMusic;
    public AudioSource levelsMusic;
    public AudioSource THEMusic;
    public AudioSource victory;
    public AudioSource story;
    public AudioSource startGameSound;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicController>().Length;
        if (numMusicPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 10)
        {
            if (!menuMusic.isPlaying)
            {
                menuMusic.Play();
            }
            if (levelsMusic.isPlaying)
            {
                levelsMusic.Stop();
            }
            if (THEMusic.isPlaying)
            {
                THEMusic.Stop();
            }
            if (victory.isPlaying)
            {
                victory.Stop();
            }
            if (story.isPlaying)
            {
                story.Stop();
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (menuMusic.isPlaying)
            {
                menuMusic.Stop();
            }
            if (THEMusic.isPlaying)
            {
                THEMusic.Stop();
            }
            if (!levelsMusic.isPlaying)
            {
                levelsMusic.Play();
            }
            if (victory.isPlaying)
            {
                victory.Stop();
            }
            if (story.isPlaying)
            {
                story.Stop();
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (menuMusic.isPlaying)
            {
                menuMusic.Stop();
            }
            if (levelsMusic.isPlaying)
            {
                levelsMusic.Stop();
            }
            if (!THEMusic.isPlaying)
            {
                THEMusic.Play();
            }
            if (victory.isPlaying)
            {
                victory.Stop();
            }
            if (story.isPlaying)
            {
                story.Stop();
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            if (menuMusic.isPlaying)
            {
                menuMusic.Stop();
            }
            if (levelsMusic.isPlaying)
            {
                levelsMusic.Stop();
            }
            if (THEMusic.isPlaying)
            {
                THEMusic.Stop();
            }
            if (!victory.isPlaying)
            {
                victory.Play();
            }
            if (story.isPlaying)
            {
                story.Stop();
            }
        }else if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 4 || 
                SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (menuMusic.isPlaying)
            {
                menuMusic.Stop();
            }
            if (levelsMusic.isPlaying)
            {
                levelsMusic.Stop();
            }
            if (THEMusic.isPlaying)
            {
                THEMusic.Stop();
            }
            if (victory.isPlaying)
            {
                victory.Stop();
            }
            if (!story.isPlaying)
            {
                story.Play();
            }
        }
    }
    
    public void gameStart()
    {
        startGameSound.Play();
    }

}
