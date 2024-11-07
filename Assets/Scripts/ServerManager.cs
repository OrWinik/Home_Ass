using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;
using DG.Tweening;

// Class for the details of each product
[System.Serializable]
public class Product
{
    public string name;
    public string description;
    public float price;
}

// Class for the list of products 
[System.Serializable]
public class ProductList
{
    public Product[] products;
}


public class ServerManager : MonoBehaviour
{
    // List of products
    [SerializeField] private ProductList productList;

    // URL link
    private string url = "https://homework.mocart.io/api/products";

    // UI
    [SerializeField] private TMP_InputField productNumberToChange;
    [SerializeField] private TMP_InputField change_Name;
    [SerializeField] private TMP_InputField change_Price;
    [SerializeField] private TextMeshProUGUI confirmationText , errorText;

    //Shelf
    [SerializeField] private GameObject shelf;
    [SerializeField] private GameObject[] shelfItems;


    void Start()
    {
        // Starting the corutine
        StartCoroutine(Get_Data_From_Server());

        // Fixing the resolution based on the platform
        if (!Application.isMobilePlatform)
        {
            Camera.main.fieldOfView = 60f;  // PC FOV
        }
        else
        {
            Camera.main.fieldOfView = 120f;  // Mobile FOV
            shelf.transform.position = new Vector3(0,-0.07f, -7f);
        }
    }

    // Courotine for getting the data from the server
    IEnumerator Get_Data_From_Server()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log("Request successful!");

                string json = request.downloadHandler.text;

                Debug.Log("Received JSON: " + json);

                // Parsing the JSON - taking the data from the server into the product list class
                productList = JsonUtility.FromJson<ProductList>(json);

                // Activating shelf items based on the amount of products
                ActivateShelfItems(productList.products);

                // Access to each of the products in productsList and its members 
                foreach (var product in productList.products)
                {

                    Debug.Log($"Name: {product.name}, Description: {product.description}, Price: {product.price}");
                }
            }
        }
    }

    // Method to activate shelf items based on the fetched data and add 
    public void ActivateShelfItems(Product[] products)
    {
        for (int i = 0; i < products.Length; i++)
        {
            // Activate the shelf items
            shelfItems[i].SetActive(true);
            Debug.Log($"Activated item: {products[i].name}");

            var nameText = shelfItems[i].transform.Find("NameText").GetComponent<TextMeshPro>();
            var priceText = shelfItems[i].transform.Find("PriceText").GetComponent<TextMeshPro>();

            nameText.text = products[i].name;
            priceText.text = products[i].price.ToString();
        }
    }

    // Method for changing the values of the products names and prices
    public void ChangeProductValues()
    {
        int indexRecived = int.Parse(productNumberToChange.text);

        // Validation
        if (indexRecived <= productList.products.Length && indexRecived >= 1 && indexRecived == Mathf.Floor(indexRecived))
        {
            // Showing confirmation text
            confirmationText.gameObject.SetActive(true);

            // Updating product values
            productList.products[indexRecived - 1].name = change_Name.text;
            productList.products[indexRecived - 1].price = int.Parse(change_Price.text);

            // Updating shelf values
            var nameText = shelfItems[indexRecived - 1].transform.Find("NameText").GetComponent<TextMeshPro>();
            var priceText = shelfItems[indexRecived - 1].transform.Find("PriceText").GetComponent<TextMeshPro>();

            nameText.text = productList.products[indexRecived - 1].name;
            priceText.text = productList.products[indexRecived - 1].price.ToString();

            // Deleting the confirmation text
            StartCoroutine(ShowConfirmation(confirmationText));
        }
        else
        {
            // Showing the error
            errorText.gameObject.SetActive(true);
            StartCoroutine(ShowConfirmation(errorText));
        }
    }

    // Delay to remove the confirmation text
    IEnumerator ShowConfirmation(TextMeshProUGUI messege)
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(2);

        //deleting the messehe
        if(messege == confirmationText)
            confirmationText.gameObject.SetActive(false);
        else
            errorText.gameObject.SetActive(false);

    }


}
