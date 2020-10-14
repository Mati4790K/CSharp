using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;

    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public int isUpgraded = 1;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
 
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;


        BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost1)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= blueprint.cost1;

        GameObject _turret = Instantiate(blueprint.prefab1, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        BuildManager.instance.towersBuild++;
        buildManager.turretToBuild = null;

        isUpgraded = 1;
}

    public void UpgradeTurret()
    {
        if (isUpgraded == 1)
        {
            if (PlayerStats.Money < turretBlueprint.upgradeCost2)
            {
                Debug.Log("Not enough money to upgrade");
                return;
            }

            PlayerStats.Money -= turretBlueprint.upgradeCost2;

            //destroy old tower model
            Destroy(turret);

            //build new tower model
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab2, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 3f);

            isUpgraded = 2;
        }

        else if (isUpgraded == 2)
        {
            if (PlayerStats.Money < turretBlueprint.upgradeCost3)
            {
                Debug.Log("Not enough money to upgrade");
                return;
            }

            PlayerStats.Money -= turretBlueprint.upgradeCost3;

            //destroy old tower model
            Destroy(turret);

            //build new tower model
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab3, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 3f);

            isUpgraded = 3;
        }

        else if (isUpgraded == 3)
        {
            if (PlayerStats.Money < turretBlueprint.upgradeCost4)
            {
                Debug.Log("Not enough money to upgrade");
                return;
            }

            PlayerStats.Money -= turretBlueprint.upgradeCost4;

            //destroy old tower model
            Destroy(turret);

            //build new tower model
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab4, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 3f);

            isUpgraded = 4;
        }

        else if (isUpgraded == 4)
        {
            if (PlayerStats.Money < turretBlueprint.upgradeCost5)
            {
                Debug.Log("Not enough money to upgrade");
                return;
            }

            PlayerStats.Money -= turretBlueprint.upgradeCost5;

            //destroy old tower model
            Destroy(turret);

            //build new tower model
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab5, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 3f);

            isUpgraded = 5;
        }
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        isUpgraded = 1;
    }
}

