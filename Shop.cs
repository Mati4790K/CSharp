using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint archerTower;
    public TurretBlueprint mageTower;
    public TurretBlueprint freezyTower;
    BuildManager buildManager;



    public GameObject shop;
    public GameObject btn_shop;


    private void Start()
    {
        buildManager = BuildManager.instance;
        Time.timeScale = 1f;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Purchased Archer");
        buildManager.SelectTurretToBuild(archerTower);
        shop.SetActive(false);
        btn_shop.SetActive(true);
    }
    public void SelectMage()
    {
        Debug.Log("Purchased Mage");
        buildManager.SelectTurretToBuild(mageTower);
        shop.SetActive(false);
        btn_shop.SetActive(true);
    }
    public void SelectFreezy()
    {
        Debug.Log("Purchased Freezy");
        buildManager.SelectTurretToBuild(freezyTower);
        shop.SetActive(false);
        btn_shop.SetActive(true);
    }

}
