using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _text;

    private int _count;

    private void OnEnable()
    {
        _player.GettingDiamond += Add;
    }

    private void OnDisable()
    {
        _player.GettingDiamond -= Add;

    }

    public void Add(int count)
    {
        _count += count;
        _text.text = _count.ToString();

    }
    public void Remove(int count)
    {
        _count -= count;
    }
}
