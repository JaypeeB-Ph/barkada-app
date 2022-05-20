using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveWindowScript : MonoBehaviour
{
    public GameObject inputFieldPrefab;
    public GameObject target;

    InstantiateNewWindowScript script;


    public void AddNewInputField()
    {
        GameObject newInputField =  Instantiate(inputFieldPrefab);
        newInputField.transform.SetParent(target.transform);
    }


    public void AddNewWindow()
    {
        // getting the parent object script and using its method
        script = transform.parent.gameObject.GetComponent<InstantiateNewWindowScript>();
        script.InstantiateNewWindow();
    }
}
