using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _mainPanel;

    public void StartShopPanel()
    {
        _mainPanel.SetActive(false);
        _shopPanel.SetActive(true);
    }
}
