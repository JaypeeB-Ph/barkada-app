using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNewWindowScript : MonoBehaviour
{
    public GameObject windowPrefab;
    


    public void InstantiateNewWindow()
    {
        GameObject window = Instantiate(windowPrefab);
        window.transform.SetParent(this.transform);
    }
}
