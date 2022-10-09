using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHealthCounter : HealthCounter
{
    [SerializeField] private Player _player; 

    private void OnEnable()
    {
        _player.LostHealth += RemoveLife;
        _player.GotHealth += AddLife;
    }
    
    private void OnDisable()
    {
        _player.LostHealth -= RemoveLife;
        _player.GotHealth -= AddLife;
    }
}
