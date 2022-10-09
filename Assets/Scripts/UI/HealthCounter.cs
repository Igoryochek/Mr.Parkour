using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class HealthCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthCountText;
    [SerializeField] private TextMeshProUGUI _restoringTimeText;
    [SerializeField] private int _startHealthCount;
    [SerializeField] private int _restoringTime;

    private int _count;
    private int _maxCount = 5;
    private Coroutine _restoringLife;

    public int Count => _count;

    private void Start()
    {
        if (PlayerPrefs.HasKey("healthsCount"))
        {
            _count = PlayerPrefs.GetInt("healthsCount");
            if (_count > _maxCount)
            {
                _count = _maxCount;
            }
        }
        else
        {
            _count = _startHealthCount;
        }
        if (_count<1)
        {
           _restoringLife= StartCoroutine(RestoringLife());
        }
        _healthCountText.text = _count.ToString();

    }

    public void AddLife()
    {
        if (_restoringLife!=null)
        {
            StopRestoring();
        }
        _count += 1;
        _healthCountText.text = _count.ToString();
        Show();
    }

    public void RemoveLife()
    {
        _count -= 1;
        _healthCountText.text = _count.ToString();
        Show();
    }

    private IEnumerator RestoringLife()
    {
        _restoringTimeText.gameObject.SetActive(true);
        for (int i = _restoringTime; i > 0; i--)
        {
            _restoringTimeText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        AddLife();
        _restoringTimeText.gameObject.SetActive(false);

    }

    private void StopRestoring()
    {
        StopCoroutine(_restoringLife);
        _restoringTimeText.gameObject.SetActive(false);
    }

    private void Show()
    {
        _healthCountText.text = _count.ToString();
        PlayerPrefs.SetInt("healthsCount", _count);
    }
}
