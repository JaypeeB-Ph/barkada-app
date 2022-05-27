using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualOrderScript : MonoBehaviour
{
    [SerializeField] Text itemText, qtyText;


    public void SetItemText(string item)
    {
        this.itemText.text = item;
    }

    public void SetQTYText(int qty)
    {
        this.qtyText.text = qty.ToString();
    }
}
