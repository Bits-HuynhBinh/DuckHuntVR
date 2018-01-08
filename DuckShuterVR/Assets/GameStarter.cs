using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public void ButtonStartClick()
    {
        SceneManager.LoadScene("Scene", LoadSceneMode.Single);
    }

    public void ButtonQuickClick()
    {
        Application.Quit();
    }

}
