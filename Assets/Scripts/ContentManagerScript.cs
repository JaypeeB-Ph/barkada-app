using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManagerScript : MonoBehaviour
{
    private List<Customer> customerList = new List<Customer>();
    [SerializeField] ContentManagerForCustomerScript cmsc;

    public void AddCustomer(Customer customer)
    {
        this.customerList.Add(customer);
    }

    public void ShowData()
    {
        Customer customer;

        for(int i = 0; i <= customerList.Count - 1; i++)
        {
            customer = customerList[i];
            List<string> items = customer.GetItemList();
            List<double> prices = customer.GetPriceList();
            Debug.Log(customer.GetName());

            //items and price
            for (int x = 0; x <= items.Count - 1; x++)
            {
                Debug.Log(items[x]);
                Debug.Log(prices[x]);
            }
        }
    }


    public void RemoveFromList(string name)
    {
        Customer customer;

        for (int i = 0; i <= customerList.Count - 1; i++)
        {
            customer = customerList[i];
            if(customer.GetName() == name)
            {
                Debug.Log(customer.GetName() + " was removed from the list.");
                customerList.RemoveAt(i);
              
                break;
            }
     
        }
    }


    public void CloneCustomerList()
    {
        cmsc.SetCustomers(customerList);
        PlayerPrefs.SetInt("Calculate", 1);
    }

}
