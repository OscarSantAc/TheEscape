using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject clickOption;
    public GameObject spaceOption;

    private void Start()
    {
        GlobalVariables.setLangChange(false);
        if(GlobalVariables.getClick()){
            clickOption.SetActive(true);
            spaceOption.SetActive(false);
        }
        else
        {
            clickOption.SetActive(false);
            spaceOption.SetActive(true);
        }
    }

    public void changeControls()
    {
        bool click = GlobalVariables.getClick();
        GlobalVariables.setClick(!click);
    }

    public void changeLanguage()
    {
        GlobalVariables.setLangChange(true);
        if (GlobalVariables.getLang().Equals("eng"))
        {
            GlobalVariables.setLang("esp");
            GlobalVariables.setOptions(true);
            SceneManager.LoadScene(10);
        }
        else
        {
            GlobalVariables.setLang("eng");
            GlobalVariables.setOptions(true);
            SceneManager.LoadScene(1);
        }
    }
}
