using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeleteWindowButton : MonoBehaviour
{
    public GameObject window;

    public void DeleteWindow()
    {

        Destroy(this.window);
    }
}
