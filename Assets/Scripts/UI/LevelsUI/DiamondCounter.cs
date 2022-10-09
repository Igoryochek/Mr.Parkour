using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _text;

    private int _count;
    private int _startCount;

    public int Count=>_count;
    public int StartCount=>_startCount;

    private void OnEnable()
    {
        _player.GotDiamond += Add;
    }

    private void OnDisable()
    {
        _player.GotDiamond -= Add;

    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("crystalsCount"))
        {
            _count = PlayerPrefs.GetInt("crystalsCount");
        }
        _text.text = _count.ToString();
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
