using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponsiveWindowScript : MonoBehaviour
{
    [Header("Reference objects")]
    [SerializeField] GameObject calculatePanel;
    [SerializeField] Button deleteButton;
    [SerializeField] Button addNewButton;
    [SerializeField] Button calculateButton;



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

    //click track
    private int clickTrack;


    //MONOBEHAVIOUR

   
    private void Update()
    {
        cm = transform.parent.gameObject.GetComponent<ContentManagerScript>();
        


        for(int i = 0; i <= current; i++)
        {
            if ((itemNameIF[i].text.Length <= 0 || priceIF[i].text.Length <= 0)
                || nameIF.text.Length <= 0)
            {
                addNewButton.interactable = false;
                calculateButton.interactable = false;
            }
            else
            {
                addNewButton.interactable = true;
                calculateButton.interactable = true;
            }
            
        }

    }



    //INSTANTIATIONS

    public void AddNewInputField()
    {
        StartCoroutine(ClickTrack());
        clickTrack++;
        if(clickTrack >= 2)
        {
            if (current <= inputFieldsHolder.Length - 1)
            {
                inputFieldsHolder[current].SetActive(true);
                current++;
            }

            clickTrack = 0;
        }
       
    }


    public void AddNewWindow()
    {
        StartCoroutine(ClickTrack());
        clickTrack++;
        if(clickTrack >= 2)
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

            //
            calculatePanel.SetActive(false);
            deleteButton.interactable = true;
            footerGameObject.SetActive(false);
            nameIF.interactable = false;

            //click track
            clickTrack = 0;
        }
        
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
        StartCoroutine(ClickTrack());
        clickTrack++;

        if(clickTrack >= 2)
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

            //
            footerGameObject.SetActive(false);
            calculatePanel.SetActive(false);

            //click track
            clickTrack = 0;

        }

    }

    public void DeleteWindow()
    {
        StartCoroutine(ClickTrack());
        clickTrack++;
        if(clickTrack >= 2)
        {
            cm.RemoveFromList(nameIF.text);
            Destroy(this.gameObject);
            clickTrack = 0;
        } 
    }


    IEnumerator ClickTrack()
    {
        yield return new WaitForSeconds(1f);
        clickTrack = 0;
    }

}
