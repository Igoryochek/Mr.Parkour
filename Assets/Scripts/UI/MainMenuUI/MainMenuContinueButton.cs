using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuContinueButton : MonoBehaviour
{
    [SerializeField] private LevelsCounter _levelsCounter;
    [SerializeField] private HealthCounter _healthCounter;
    [SerializeField] private TextMeshProUGUI _notEnoughLives;

    public void LoadLevel()
    {
        if (_healthCounter.Count>0)
        {
            SceneManager.LoadScene(_levelsCounter.CurrentLevelNumber);
        }
        else
        {
            StartCoroutine(NotEnoughLivesViewer());
        }
    }

    private IEnumerator NotEnoughLivesViewer()
    {
        _notEnoughLives.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _notEnoughLives.gameObject.SetActive(false);

    }
}
