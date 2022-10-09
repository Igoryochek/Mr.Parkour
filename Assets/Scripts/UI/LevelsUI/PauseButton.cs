using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private GameObject _pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _pauseMenu.gameObject.SetActive(true);
            _playButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
