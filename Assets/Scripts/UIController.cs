using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _finish;
    [SerializeField] private GameObject _restart;

    private void OnEnable()
    {
        _player.Finished += OnFinished;
        _player.Restarting += OnRestarting;
    }

    private void OnDisable()
    {
        _player.Finished -= OnFinished;
        _player.Restarting -= OnRestarting;
    }

    private void OnFinished()
    {
        _finish.SetActive(true);
        Time.timeScale = 0;
    }
    
    private void OnRestarting()
    {
        _restart.SetActive(true);
        Time.timeScale = 0;
    }
}
