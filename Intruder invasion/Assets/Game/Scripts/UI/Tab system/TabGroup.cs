using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Color tabIdle;
    public Color tabHovor;
    public Color tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;

    public PanelGroup panelGroup;
    
    private void OnEnable()
    {
        OnTabSelected(tabButtons[0]);
    }

    private void OnDisable()
    {
        ResetTabs();
    }

    private void SelectFirstTab()
    {
        // make it so that you have to first tab selected
        if(selectedTab != null)
            selectedTab.background.color = tabIdle;
        
        selectedTab = tabButtons[0];
        selectedTab.background.color = tabActive;
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if (i==0)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }
    
    
    public void Subscribe(TabButton button)
    {
        if (button == null)
        {
            tabButtons = new List<TabButton>();
        }
        
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHovor; 
        }
        
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
            selectedTab.Deselect();
        
        selectedTab = button;
        
        selectedTab.Select();
        
        ResetTabs();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }

        if (panelGroup != null)
        {
            panelGroup.SetPageIndex(button.transform.GetSiblingIndex());            
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab!=null && button == selectedTab){continue;}
            
            button.background.color = tabIdle;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }
}
