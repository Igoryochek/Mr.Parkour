using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private GameObject _pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            _pauseMenu.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
