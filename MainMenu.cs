using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        GlobalVariables.setOptions(false);
    }

    public void playGame()
    {
        GlobalVariables.setPower(0);
        GlobalVariables.setDeaths(0);
        GlobalVariables.setFinalTime(0);
        GlobalVariables.setStackTime(0);
        SceneManager.LoadScene(2);
        GlobalVariables.setFirstGame(false);
    }
    

    public void openScoreboard()
    {
        SceneManager.LoadScene(11);
    }

    public void exit()
    {
        Application.Quit();
    }

}
