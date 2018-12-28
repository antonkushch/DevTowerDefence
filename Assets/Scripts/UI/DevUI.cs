using Assets.Scripts.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevUI : MonoBehaviour {

    private Node target;
    public GameObject ui;
    public Text upgradeCostText;
    public Text sellCostText;

    public void SetTarget(Node target)
    {
        this.target = target;
        transform.position = target.GetBuildPlacing();
        try
        {
            var newUpgradeCost = target.dev.CostToUpgrade();
            upgradeCostText.text = "Upgrade\n" + newUpgradeCost;
        }
        catch(MaxUpgradeException ex)
        {
            upgradeCostText.text = "Upgrade\n" + ex.Message;
        }
        try
        {
            var newSellCost = target.dev.CostToSell();
            sellCostText.text = "Sell\n" + newSellCost;
        }
        catch(CantSellException ex)
        {
            sellCostText.text = "Sell\n" + ex.Message;
        }
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        Building.instance.UpgradeDev(target.dev);
        Building.instance.DeselectNode();
    }

    public void Sell()
    {
        Building.instance.SellDev(target);
        Building.instance.DeselectNode();
    }
}
