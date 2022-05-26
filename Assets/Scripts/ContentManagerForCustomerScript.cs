using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManagerForCustomerScript : MonoBehaviour
{
    private List<Customer> customers = new List<Customer>();
    [SerializeField] GameObject prefab;


    public void SetCustomers(List<Customer> customers)
    {
        this.customers = customers;
        Debug.Log("Cloning success");
    }


    private void Start()
    {
        foreach(Customer c in customers)
        {
            CustomerWindowScript cws;

            //Instantiating window
            GameObject window = Instantiate(prefab);
            window.transform.SetParent(this.transform);

            // accessing the script
            cws = window.GetComponent<CustomerWindowScript>();

            // setting name
            cws.SetCustomerName(c.GetName());

            //setting items
            int itemCount = c.GetItemCount();
            List<string> items = c.GetItemList();
            List<double> prices = c.GetPriceList();
            for (int i = 0; i <= itemCount - 1; i++)
            {
                cws.ActivateHolder(i);
                cws.SetValues(i, items[i], prices[i]);
            }
        }
    }






}
