using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private LevelHealthCounter _healthCounter;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        Debug.Log(_healthCounter.Count);
        PlayerPrefs.SetInt("healthsCount", _healthCounter.Count);
        SceneManager.LoadScene(_levelNumber);       
    }


}
