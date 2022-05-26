using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponsiveWindowScript : MonoBehaviour
{
    public GameObject inputFieldPrefab;
    public GameObject target;
    [SerializeField] GameObject footerGameObject;
    private bool showFooter = true;

    private InstantiateNewWindowScript script;

    //INPUTFIELDS
    [Header("InputFields")]
    [SerializeField] InputField nameIF;
    [SerializeField] InputField[] itemNameIF;
    [SerializeField] InputField[] priceIF;


    [Header("Array Gameobjects")]
    [SerializeField] GameObject[] inputFieldsHolder = new GameObject[4];
    int current = 0;



    //
    private Customer customer = new Customer();
    private ContentManagerScript cm;


    //MONOBEHAVIOUR

   
    private void Update()
    {
        cm = transform.parent.gameObject.GetComponent<ContentManagerScript>();

    }



    //INSTANTIATIONS
    public void AddNewInputField()
    {
        if (current <= inputFieldsHolder.Length -1) {
            inputFieldsHolder[current].SetActive(true);
            current++;

        } 
    }


    public void AddNewWindow()
    {

        customer.SetName(nameIF.text);

        if (current == 3)
        {
            current += 1;
        }

        for (int i = 0; i <= current; i++)
        {
            customer.AddItems(itemNameIF[i].text);
            customer.AddPrices(double.Parse(priceIF[i].text));

            //Disabling all inputfields when clicking new
            itemNameIF[i].interactable = false;
            priceIF[i].interactable = false;
        }


        cm.AddCustomer(customer);
        showFooter = false;


        // getting the parent object script and using its method
        script = transform.parent.gameObject.GetComponent<InstantiateNewWindowScript>();
        script.InstantiateNewWindow();
    }


    public void MaximizeWindow()
    {
        if (showFooter)
        {
            footerGameObject.SetActive(true);
        }else if (!showFooter)
        {
            footerGameObject.SetActive(false);
        }
        
    }






    public void Calculate()
    {
        customer.SetName(nameIF.text);

        if (current == 3)
        {
            current += 1;
        }

        for (int i = 0; i <= current; i++)
        {
            customer.AddItems(itemNameIF[i].text);
            customer.AddPrices(double.Parse(priceIF[i].text));
        }



        cm.AddCustomer(customer);

        //cm.ShowData();

        cm.CloneCustomerList();

    }


    public void DeleteWindow()
    {
        cm.RemoveFromList(nameIF.text);
        Destroy(this.gameObject);
    }

}
