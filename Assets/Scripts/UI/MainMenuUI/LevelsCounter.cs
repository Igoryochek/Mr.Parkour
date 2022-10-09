using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelCounterText;

    private int _currentLevelNumber;

    public int CurrentLevelNumber => _currentLevelNumber;

    private void Start()
    {
        if (PlayerPrefs.HasKey("levelNumber"))
        {
            _currentLevelNumber = PlayerPrefs.GetInt("levelNumber");
            if (_currentLevelNumber==0)
            {
                PlayerPrefs.SetInt("levelNumber", 1);
                _currentLevelNumber = 1;
            }
        }
        else
        {
            _currentLevelNumber = 1;
        }

        _levelCounterText.text ="уровень: "+ _currentLevelNumber.ToString();
    }
}
