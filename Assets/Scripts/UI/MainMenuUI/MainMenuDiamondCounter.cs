using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuDiamondCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _count;

    public int Count=>_count;

    private void Start()
    {
        if (PlayerPrefs.HasKey("crystalsCount"))
        {
            int count=PlayerPrefs.GetInt("crystalsCount");
            _count = count;
        }
        else
        {
            _count = 0;
        }
        ShowCount();
    }

    public void OnDiamondsRemoved(int count)
    {
        _count -= count;
        ShowCount();
    }
    
    public void OnDiamondsAdded(int count)
    {
        _count += count;
        ShowCount();
    }

    private void ShowCount()
    {
        _text.text = _count.ToString();
        PlayerPrefs.SetInt("crystalsCount",_count);
    }
}
