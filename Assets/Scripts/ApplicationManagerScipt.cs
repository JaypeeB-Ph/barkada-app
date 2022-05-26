using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManagerScipt : MonoBehaviour
{
    [SerializeField] GameObject mainWindow;
    [SerializeField] GameObject finalWindow;

    private void Start()
    {
        PlayerPrefs.SetInt("Calculate", 0);
    }

    private void Update()
    {
       if(PlayerPrefs.GetInt("Calculate") == 1)
        {
            mainWindow.SetActive(false);
            finalWindow.SetActive(true);
            PlayerPrefs.SetInt("Calculate", 0);
        }
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
