using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Text timer;
    public Text deaths;
    public GameObject engScreen;
    public GameObject espScreen;

    private void Start()
    {
        if (GlobalVariables.getLang().Equals("esp"))
        {
            espScreen.SetActive(true);
            engScreen.SetActive(false);
        }
        else
        {
            espScreen.SetActive(false);
            engScreen.SetActive(true);
        }
        float t = GlobalVariables.getFinalTime();
        string m = ((int)t / 60).ToString();
        string s = (t % 60).ToString("f3");
        timer.text = m + ":" + s;
        deaths.text = GlobalVariables.getDeaths().ToString();
        Score highScore = DatabaseController.loadHighScore();
        if (highScore.getTime() > t)
        {
            Score newHighScore = new Score();
            DatabaseController.saveHighScore(newHighScore);

        }
        else if (highScore.getTime() == t && highScore.getDeaths() >= GlobalVariables.getDeaths())
        {
            Score newHighScore = new Score();
            DatabaseController.saveHighScore(newHighScore);
        }
    }

    public void goToMenu()
    {
        GlobalVariables.setOptions(false);
        string lang = GlobalVariables.getLang();
        if (lang.Equals("eng"))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(10);
        }
    }
}
