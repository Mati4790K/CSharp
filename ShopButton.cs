using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject shop;
    public GameObject btn_shop;

    public void Open()
    {
        shop.SetActive(true);
        btn_shop.SetActive(false);
    }

    public void Close()
    {
        shop.SetActive(false);
        btn_shop.SetActive(true);
    }
}
