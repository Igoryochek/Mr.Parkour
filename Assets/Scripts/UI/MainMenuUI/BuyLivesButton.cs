using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using TMPro;

public class BuyLivesButton : MonoBehaviour
{
    [SerializeField] private MainMenuDiamondCounter _diamondCounter;
    [SerializeField] private MainMenuHealthCounter _healthCounter;
    [SerializeField] private TextMeshProUGUI _notEnoughDiamondsText;
    [SerializeField] private TextMeshProUGUI _maxLivesCountText;
    [SerializeField] private int _payCount;

    public void AddLive()
    {
        if (_diamondCounter.Count>=_payCount&&_healthCounter.Count<5)
        {
            _diamondCounter.OnDiamondsRemoved(_payCount);
            _healthCounter.AddLife();
        }
        else if (_diamondCounter.Count < _payCount)
        {
            StartCoroutine(ShowNotEnoughDiamondText());
        }
        else if (_healthCounter.Count >= 5)
        {
            StartCoroutine(ShowMaxLivesCountText());
        }

    }

    private IEnumerator ShowNotEnoughDiamondText()
    {
        _notEnoughDiamondsText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _notEnoughDiamondsText.gameObject.SetActive(false);
    }
    
    private IEnumerator ShowMaxLivesCountText()
    {
        _maxLivesCountText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _maxLivesCountText.gameObject.SetActive(false);
    }
         
}

