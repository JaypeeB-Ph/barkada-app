using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScript : MonoBehaviour
{
    [SerializeField] float interval = 2;
    private int w, h;
    private void Awake()
    {
        w = Screen.width;
        h = Screen.height;
        Debug.Log("W: " + w + " H: " + h);
    }


    private void Start()
    {
        StartCoroutine(Splash());
    }

    IEnumerator Splash()
    {
        yield return new WaitForSeconds(interval);
        if(w == 1080 && h == 1920)
        {
            SceneManager.LoadScene(1);
        }
        else if (w == 1080 && h == 2400)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
        
    }
}
