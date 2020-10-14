using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject uiClose;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (target.isUpgraded == 1)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost2;
            upgradeButton.interactable = true;
        }
        else if (target.isUpgraded == 2)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost3;
            upgradeButton.interactable = true;
        }
        else if (target.isUpgraded == 3)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost4;
            upgradeButton.interactable = true;
        }
        else if (target.isUpgraded == 4)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost5;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);
        uiClose.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
        uiClose.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
