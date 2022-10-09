using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContinueButton : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _mainMenuPanel;

    public void StartMainMenu()
    {
        _shopPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
}
