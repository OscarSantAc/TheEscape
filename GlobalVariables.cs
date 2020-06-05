using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    private static bool click=true;
    private static float stackTime = 0;
    private static float finalTime = 5999.999f;
    private static int power = 0;
    private static bool frozenTime = false;
    private static string lang = "eng";
    private static bool options = false;
    private static bool languageChange = false;
    private static string name;
    private static int deaths=0;
    private static bool firstGame = true;

    public static void setClick(bool click2)
    {
        click = click2;
    }

    public static bool getClick()
    {
        return click;
    }

    public static void setStackTime(float t)
    {
        stackTime = t;
    }

    public static float getStackTime()
    {
        return stackTime;
    }

    public static void setFinalTime(float t)
    {
        finalTime = t;
    }

    public static float getFinalTime()
    {
        return finalTime;
    }

    public static void setPower(int pow)
    {
        power = pow;
    }

    public static int getPower()
    {
        return power;
    }

    public static void setFrozenTime(bool frozen)
    {
        frozenTime = frozen;
    }

    public static bool getFrozenTime()
    {
        return frozenTime;
    }

    public static void setLang(string nLang)
    {
        lang = nLang;
    }

    public static string getLang()
    {
        return lang;
    }

    public static void setOptions(bool opt)
    {
        options = opt;
    }

    public static bool getOptions()
    {
        return options;
    }

    public static void setLangChange(bool change)
    {
        languageChange = change;
    }

    public static bool getLangChange()
    {
        return languageChange;
    }

    public static void setName(string n)
    {
        name = n;
    }

    public static string getName()
    {
        return name;
    }

    public static void addDeath()
    {
        deaths++;
    }

    public static void setDeaths(int d)
    {
        deaths = d;
    }

    public static int getDeaths()
    {
        return deaths;
    }
    public static void setFirstGame(bool f)
    {
        firstGame = f;
    }

    public static bool getFirstGame()
    {
        return firstGame;
    }

}
