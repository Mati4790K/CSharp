using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab1;
    public int cost1;

    public GameObject upgradedPrefab2;
    public int upgradeCost2;

    public GameObject upgradedPrefab3;
    public int upgradeCost3;

    public GameObject upgradedPrefab4;
    public int upgradeCost4;

    public GameObject upgradedPrefab5;
    public int upgradeCost5;

    public int GetSellAmount()
    {
        return cost1 / 2;
    }

}
