using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SplashScript : MonoBehaviour
{
    [SerializeField] GameObject mainWindow, splashWindow;
    [SerializeField] float interval = 2;

    private void Start()
    {
        StartCoroutine(Splash());
    }

    IEnumerator Splash()
    {
        yield return new WaitForSeconds(interval);
        splashWindow.SetActive(false);
        mainWindow.SetActive(true);
    }
}
