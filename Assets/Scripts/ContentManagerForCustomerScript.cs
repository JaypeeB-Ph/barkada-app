using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManagerForCustomerScript : MonoBehaviour
{
    private List<Customer> customers = new List<Customer>();
    [SerializeField] GameObject prefab;


    [Header("OverallTotal and Summary")]
    [SerializeField] Text totalValueText;
    [SerializeField] GameObject individualPanelPrefab, summaryPanel;
    [SerializeField] GameObject targetPanelForSummaryOrders;

    private double totalValue;
    private List<Orders> orders = new List<Orders>();
    private List<string> itemNameList = new List<string>();

    public void SetCustomers(List<Customer> customers)
    {
        this.customers = customers;
        for(int i = 0; i <= customers.Count -1; i++)
        {
            List<string> itemList = customers[i].GetItemList();
            int size = itemList.Count;

            for (int x = 0; x <= size - 1; x++)
            {
                itemNameList.Add(itemList[x]);
            }

        }
        Debug.Log("Cloning success");
        Debug.Log("ItemNameList size: " + itemNameList.Count);
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

                //calculating overall total
                totalValue += prices[i];
            }
        }


        totalValueText.text = "\u20B1".ToString() + " " + totalValue.ToString();
    }


    public void ShowOrderSummary()
    {
       
        Summarize();

        foreach (Orders o in orders)
        {
            IndividualOrderScript ios;

            //Instantiating window
            GameObject panel = Instantiate(individualPanelPrefab);
            panel.transform.SetParent(targetPanelForSummaryOrders.transform);
            // accessing the script
            ios = panel.GetComponent<IndividualOrderScript>();

            //setting values
            ios.SetItemText(o.GetItem());
            ios.SetQTYText(o.GetQty());
        }

    }

    private void Summarize()
    {
        int quantity = 0;
        string itemName;
        int count = itemNameList.Count - 1;

        List<string> savedItems = new List<string>();

        for (int i = 0; i <= count ; i++)
        {
            itemName = itemNameList[i].ToUpper();

            for(int x = 0; x <= count; x++)
            {
                if (itemName.Equals(itemNameList[x].ToUpper()))
                {
                    quantity += 1;
                }
            }

            if (!savedItems.Contains(itemName))
            {
                savedItems.Add(itemName);
                Orders order = new Orders();
                order.SetItem(itemName);
                order.SetQty(quantity);
                orders.Add(order);
            }

            quantity = 0;
        }

        summaryPanel.SetActive(true);

    }




}
