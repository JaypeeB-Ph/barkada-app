using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveWindowScript : MonoBehaviour
{
    public GameObject inputFieldPrefab;
    public GameObject target;


    public void addNewInputField()
    {
        GameObject newInputField =  Instantiate(inputFieldPrefab);
        newInputField.transform.SetParent(target.transform);
    }
}
