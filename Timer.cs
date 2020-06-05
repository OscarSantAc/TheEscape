using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text deathtext;
    private float startTime;
    private float previousTime;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        previousTime = GlobalVariables.getStackTime();
    }

    // Update is called once per frame
    void Update()
    {
        t = Time.time - startTime + previousTime;
        string m = ((int)t / 60).ToString();
        string s = (t % 60).ToString("f3");

        timerText.text = m + ":" + s;
        deathtext.text = GlobalVariables.getDeaths().ToString();
    }

    public void saveTime(bool final)
    {
        if (!final)
        {
            GlobalVariables.setStackTime(t);
        }
        else
        {
            GlobalVariables.setFinalTime(t);
        }
    }
    
}
