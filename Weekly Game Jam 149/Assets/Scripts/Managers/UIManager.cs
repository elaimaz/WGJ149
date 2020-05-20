﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is NULL");
            }
            return _instance;
        }
    }

    public GameObject OrderPanel;
    public GameObject DescriptionPanel;
    public GameObject RightWrongPanel;

    public GameObject LastOneLeftSprite;
    public GameObject CreatedPotion;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateOrderPanelText(string order, string rock, string liquid, string magic)
    {
        Text text = OrderPanel.GetComponentInChildren<Text>();
        text.text = "Order: " + order + "\n\nRecipe:" + rock + " + " + liquid + " + " + magic;
    }

    public void UpdateDescriptionPanelText(string description, string title, string type)
    {
        Text text = DescriptionPanel.GetComponentInChildren<Text>();
        Text itemName = DescriptionPanel.transform.GetChild(1).GetComponent<Text>();
        text.text = "Description: " + description + "\n\nType: " + type;
        itemName.text = "Item: " + title;
    }

    public void UpdateLastOneImage(Sprite sprite)
    {
        LastOneLeftSprite.GetComponent<Image>().sprite = sprite;
    }

    public void CallMix()
    {
        GameManager.Instance.Mix();
    }

    public void RightPanel()
    {
        RightWrongPanel.SetActive(true);
        Text text = RightWrongPanel.GetComponentInChildren<Text>();
        text.color = Color.green;
        text.text = "Right Mix";
    }

    public void WrongPanel()
    {
        RightWrongPanel.SetActive(true);
        Text text = RightWrongPanel.GetComponentInChildren<Text>();
        text.color = Color.red;
        text.text = "Wrong Mix";
    }

    public void TimesUpPanel()
    {
        RightWrongPanel.SetActive(true);
        Text text = RightWrongPanel.GetComponentInChildren<Text>();
        text.color = Color.yellow;
        text.text = "Time Ended";
    }

    public void RestartOrder()
    {
        GameManager.Instance.ChooseRandomOrder();
        GameManager.Instance.time = 31f;
        GameManager.Instance.timeUp = false;
        GameManager.Instance.timeStop = false;
        GameManager.Instance.lastOneLeft.Name = "";
        LastOneLeftSprite.GetComponent<Image>().sprite = null;
        CreatedPotion.GetComponent<Image>().sprite = null;
    }

    public void CloseRightWrongPanel()
    {
        RightWrongPanel.SetActive(false);
    }

    public void UpdateTimer()
    {
        int timer = (int)GameManager.Instance.time;
        OrderPanel.transform.GetChild(1).GetComponent<Text>().text = "Time: " + timer.ToString();
    }
}
