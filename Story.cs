using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    bool click;
    public GameObject engStory;
    public GameObject espStory;
    public GameObject engClick;
    public GameObject espClick;
    public GameObject engSpace;
    public GameObject espSpace;


    private void Start()
    {
        click = GlobalVariables.getClick();
        string lang = GlobalVariables.getLang();
        if (lang.Equals("esp"))
        {
            engStory.SetActive(false);
            espStory.SetActive(true);
            if (click)
            {
                engClick.SetActive(false);
                espClick.SetActive(true);
            }
            else
            {
                engClick.SetActive(false);
                espSpace.SetActive(true);
            }
        }
        else if(!click)
        {
            engClick.SetActive(false);
            engSpace.SetActive(true);
        }
    }
    
    void Update()
    {
        if (click)
        {
            if (Input.GetMouseButtonDown(0))
            {
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene + 1);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene + 1);
            }
        }
    }
}
