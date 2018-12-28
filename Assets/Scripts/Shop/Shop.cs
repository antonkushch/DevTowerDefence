using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    private Building building;
    private List<int> costs;
    public ShopItem juniorDev;
    public ShopItem middleDev;
    public ShopItem seniorDev;

    void Awake()
    {
        costs = new List<int>();
        var allFields = typeof(Shop).GetFields();
        for (int i = 0; i < allFields.Length; i++)
        {
            if(allFields[i].FieldType == typeof(ShopItem))
            {
                var shopItem = (ShopItem)allFields[i].GetValue(this);
                costs.Add(shopItem.cost);
            }
        }

        SetCostOfDevs();
    }

    void Start()
    {
        building = Building.instance;
    }

    private void SetCostOfDevs()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            SetCostOfDev(transform.GetChild(i), i);
        }
    }

    private void SetCostOfDev(Transform parent, int index)
    {
        if (parent.tag == "CostText")
        {
            parent.GetComponent<Text>().text = costs[index].ToString();
            return;
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            SetCostOfDev(parent.GetChild(i), index);
        }
        return;
    }

	public void SelectJuniorDevShopItem()
    {
        building.SelectDevToPlace(juniorDev);
    }

    public void SelectMiddleDevShopItem()
    {
        building.SelectDevToPlace(middleDev);
    }

    public void SelectSeniorDevShopItem()
    {
        building.SelectDevToPlace(seniorDev);
    }
}
