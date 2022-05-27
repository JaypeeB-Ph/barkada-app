using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    private string name;
    private List<string> items = new List<string>();
    private List<double> prices = new List<double>();

    public string GetName()
    {
        return this.name;
    }


    public void SetName(string name)
    {
        this.name = name;
    }

    public List<string> GetItemList()
    {
        return this.items;
    }

    public int GetItemCount()
    {
        return this.items.Count;
    }

    public List<double> GetPriceList()
    {
        return this.prices;
    }

    public int GetPricesCount()
    {
        return this.prices.Count;
    }



    public void AddItems(string item)
    {
        this.items.Add(item);
    }

    public void AddPrices(double price)
    {
        this.prices.Add(price);
    }

}
