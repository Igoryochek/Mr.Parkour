using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private DiamondCounter _diamondCounter;
    [SerializeField] private LevelHealthCounter _healthCounter;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _finish;
    [SerializeField] private GameObject _restart;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _notEnoughHealthText;
    [SerializeField] private BonusViewer _hourGlassViewer;
    [SerializeField] private BonusViewer _jumpBonusViewer;
    [SerializeField] private BonusViewer _shieldJumpBonusViewer;
    [SerializeField] private TextMeshProUGUI _levelNumber;


    private void OnEnable()
    {
        _player.Finished += OnFinished;
        _player.Restarting += OnRestarting;
        _player.GotJumpBonus += OnGotJumpBonus;
        _player.GotShieldJumpBonus += OnGotShieldJumpBonus;
        _player.GotHourGlass += OnGotHourGlass;
    }

    private void OnDisable()
    {
        _player.Finished -= OnFinished;
        _player.Restarting -= OnRestarting;
        _player.GotJumpBonus -= OnGotJumpBonus;
        _player.GotShieldJumpBonus -= OnGotShieldJumpBonus;
        _player.GotHourGlass -= OnGotHourGlass;

    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("levelNumber"))
        {
            _levelNumber.text ="уровень: "+ PlayerPrefs.GetInt("levelNumber").ToString();
        }
        else
        {
            _levelNumber.text = "уровень: " + 1.ToString();

        }
    }

    private void OnFinished()
    {
        PlayerPrefs.SetInt("crystalsCount", _diamondCounter.Count);
        PlayerPrefs.SetInt("healthsCount", _healthCounter.Count);
        _finish.SetActive(true);
        Time.timeScale = 0;
    }
    
    private void OnGotHourGlass()
    {
        _hourGlassViewer.gameObject.SetActive(true);
        _hourGlassViewer.StartViewer();
    }
    
    private void OnRestarting()
    {

        if (_healthCounter.Count <= 0)
        {
            StartCoroutine(GoToMainMenu());
        }
        else
        {
            _restart.SetActive(true);
        }
    }
    
    private void OnGotJumpBonus()
    {
        _jumpBonusViewer.gameObject.SetActive(true);
        _jumpBonusViewer.StartViewer();

    }

    private void OnGotShieldJumpBonus()
    {
        _shieldJumpBonusViewer.gameObject.SetActive(true);
        _shieldJumpBonusViewer.StartViewer();

    }

    private IEnumerator GoToMainMenu()
    {
        _notEnoughHealthText.SetActive(true);

        yield return new WaitForSeconds(1);
        _menu.SetActive(true);
    }
}
