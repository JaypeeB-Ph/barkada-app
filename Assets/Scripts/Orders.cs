using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders
{
    private string item;
    private int qty;



    public string GetItem()
    {
        return this.item;
    }

    public int GetQty()
    {
        return this.qty;
    }


    public void SetItem(string item)
    {
        this.item = item;
    }

    public void SetQty(int num)
    {
        this.qty = num;
    }

}
