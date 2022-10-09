using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private int _nextLevel;
    [SerializeField] private HealthCounter _healthCounter;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        _healthCounter.AddLife();
        PlayerPrefs.SetInt("levelNumber",_nextLevel);        
        SceneManager.LoadScene(_nextLevel);
        Time.timeScale = 1f;
    }
}
