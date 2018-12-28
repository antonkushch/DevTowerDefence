using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Interfaces;

public class Building : MonoBehaviour {

    public static Building instance;
    private ShopItem selectedDev;

    private IUpgradable<AbstractDeveloper> upgrading;
    private ISellable<AbstractDeveloper> selling;

    private Node selectedNode;
    public DevUI devUI;

    public GameObject upgradeEffect;

    void Awake()
    {
        upgrading = GetComponent<IUpgradable<AbstractDeveloper>>();
        selling = GetComponent<ISellable<AbstractDeveloper>>();

        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        selectedDev = null;

        devUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        devUI.Hide();
    }

    public void SelectDevToPlace(ShopItem dev)
    {
        selectedDev = dev;
        DeselectNode();
    }

    public bool DevSelected()
    {
        return selectedDev != null && selectedDev.dev != null;
    }

    public bool EnoughMoneyToBuild()
    {
        return PlayerStuff.money >= selectedDev.cost;
    }

    public void PlaceDev(Node node)
    {
        if(PlayerStuff.money < selectedDev.cost)
        {
            Debug.Log("Not enough balance.");
            return;
        }

        PlayerStuff.money -= selectedDev.cost;

        var tempDev = Instantiate(selectedDev.dev, node.GetBuildPlacing(), Quaternion.identity);
        node.dev = tempDev;
    }

    public void UpgradeDev(AbstractDeveloper dev)
    {
        upgrading.Upgrade(dev);
    }

    public void SellDev(Node node)
    {
        selling.Sell(node.dev);
        node.dev = null;
    }
}
