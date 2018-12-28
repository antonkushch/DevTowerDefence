using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color highlightColor;
    public Color notEnoughMoneyColor;
    private Renderer myRenderer;
    private Color initialColor;

    public AbstractDeveloper dev;
    public Vector3 placingOffset;

    private Building building;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        initialColor = myRenderer.material.color;
        building = Building.instance;
    }

    public Vector3 GetBuildPlacing()
    {
        return transform.position + placingOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
                
        if(dev != null)
        {
            building.SelectNode(this);
            return;
        }

        if (!building.DevSelected())
            return;

        building.PlaceDev(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!building.DevSelected())
            return;

        if (building.EnoughMoneyToBuild())
        {
            myRenderer.material.color = highlightColor;
        }
        else
        {
            myRenderer.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        myRenderer.material.color = initialColor;
    }
}
