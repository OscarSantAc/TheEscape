using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Username : MonoBehaviour
{
    private string username;
    public GameObject input;

    public void selectUsername()
    {
        username = input.GetComponent<Text>().text;
        GlobalVariables.setName(username);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene + 1);
    }
}
