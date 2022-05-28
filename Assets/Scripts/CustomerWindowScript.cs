using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerWindowScript : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] InputField nameIF;

    [SerializeField] GameObject[] IFholders;
    [SerializeField] InputField[] items;
    [SerializeField] InputField[] prices;


    [SerializeField] Text totalSumText;
    [SerializeField] InputField cash, change;

    [Header("Customize")]
    [SerializeField] Image footerImage;
    [SerializeField] Color color;


    private double total;
    private double[] pricesInDouble = new double[5];

    private double changeValue;


    private void Start()
    {
        changeValue = 0;

        //Calculating and showing total
        for (int i = 0; i <= prices.Length - 1; i++)
        {
            total += pricesInDouble[i];
        }
        totalSumText.text = "\u20B1".ToString() + "   " + total.ToString();
    }

    public void ChangeColor()
    {
        footerImage.color = color;
        cash.image.color = color;
        change.image.color = color;
        change.text = "\u20B1".ToString() + "   " + changeValue.ToString();

        //
        cash.contentType = InputField.ContentType.Standard;
        cash.text = "\u20B1".ToString() + " " + cash.text;
        cash.interactable = false;
    }


    public void CalculateChange()
    {

       

        if (cash.contentType == InputField.ContentType.IntegerNumber)
        {
            changeValue = (double.Parse(cash.text) - total);
            change.text = "\u20B1".ToString() + "   " + changeValue.ToString();    
        }     
    }

    public void SetCustomerName(string name)
    {
        this.nameIF.text = name;
    }

    public void ActivateHolder(int index)
    {
        IFholders[index].SetActive(true);
    }

    //sets the values for items and price using index
    public void SetValues(int index, string itemName, double itemPrice)
    {
        items[index].text = itemName;
        prices[index].text = itemPrice.ToString();
        pricesInDouble[index] = itemPrice;
    }
}
