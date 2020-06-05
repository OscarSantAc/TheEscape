using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject main;
    public GameObject opt;

    private void Start()
    {
        if (GlobalVariables.getOptions())
        {
            main.SetActive(false);
            opt.SetActive(true);
        }
        else
        {
            main.SetActive(true);
            opt.SetActive(false);
        }
    }

}
