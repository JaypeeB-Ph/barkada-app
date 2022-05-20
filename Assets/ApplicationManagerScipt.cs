using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManagerScipt : MonoBehaviour
{
    [SerializeField] GameObject windowPrefab;
    [SerializeField] GameObject targetSpawn;



    private void Start()
    {
        GameObject window = Instantiate(windowPrefab);
        window.transform.SetParent(targetSpawn.transform);
    }
}
