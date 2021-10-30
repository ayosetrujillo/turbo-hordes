using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Transition FX")]
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject menuPause;
   
    public DoorSwitchController doorA;

    public bool doorAUnlock = false;

    public void Awake()
    {
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menuPause.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ExitMenuPause()
    {
        menuPause.SetActive(false);
    }


}


