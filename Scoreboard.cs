using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    public GameObject back;
    public GameObject back2;
    public GameObject title;
    public GameObject title2;
    public GameObject nameLabel;
    public GameObject nameLabel2;
    public GameObject timeLabel;
    public GameObject timeLabel2;
    public GameObject deathLabel;
    public GameObject deathLabel2;
    public Text name;
    public Text time;
    public Text deaths;

    private void Start()
    {
        if (GlobalVariables.getLang().Equals("esp"))
        {
            back.SetActive(false);
            back2.SetActive(true);
            title.SetActive(false);
            title2.SetActive(true);
            nameLabel.SetActive(false);
            nameLabel2.SetActive(true);
            timeLabel.SetActive(false);
            timeLabel2.SetActive(true);
            deathLabel.SetActive(false);
            deathLabel2.SetActive(true);
        }
        else
        {
            back.SetActive(true);
            back2.SetActive(false);
            title.SetActive(true);
            title2.SetActive(false);
            nameLabel.SetActive(true);
            nameLabel2.SetActive(false);
            timeLabel.SetActive(true);
            timeLabel2.SetActive(false);
            deathLabel.SetActive(true);
            deathLabel2.SetActive(false);
        }

        Score highScore = DatabaseController.loadHighScore();
        string nick = highScore.getName();
        float t = highScore.getTime();
        string m = ((int)t / 60).ToString();
        string s = (t % 60).ToString("f3");
        int passings = highScore.getDeaths();
        name.text = nick;
        time.text = m + ":" + s;
        deaths.text = passings.ToString();
        
    }

    public void backToMenu()
    {
        if (GlobalVariables.getLang().Equals("eng"))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(10);
        }
    }

}
