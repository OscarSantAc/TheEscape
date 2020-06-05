using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Score
{
    private float time;
    private int deaths;
    private string name;

    public Score()
    {
        time = GlobalVariables.getFinalTime();
        deaths = GlobalVariables.getDeaths();
        name = GlobalVariables.getName();
    }

    public float getTime()
    {
        return time;
    }

    public void setFinalTime(float t)
    {
        time = t;
    }

    public void setName(string n)
    {
        name = n;
    }

    public string getName()
    {
        return name;
    } 

    public void setDeaths(int d)
    {
        deaths = d;
    }

    public int getDeaths()
    {
        return deaths;
    }
}
