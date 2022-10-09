using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuButton : MonoBehaviour
{
    [SerializeField] private HealthCounter _healthCounter;

    public void LoadLevel()
    {
        PlayerPrefs.SetInt("healthsCount", _healthCounter.Count);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
