using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public Image candyImage;
    public Image itemImage;
    public Text itemDescriptionText;
    public Text itemCostText;

    public ShopItem shopItem;

    public List<ShopItem> items = new List<ShopItem>();


    //private void Update()
    //{
    //    if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
    //    {
    //        if (questWindow.activeSelf)
    //        {
    //            CloseQuestWindow();
    //        }
    //        else
    //        {
    //            OpenShopMenu();
    //        }
    //    }
    //}



    public void OpenShopMenu()
        {
         shopItem.item();
           
        }


}
