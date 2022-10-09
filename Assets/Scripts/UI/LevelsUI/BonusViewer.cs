using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusViewer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Bonus _bonusPrefab;

    

    public void StartViewer()
    {
        _slider.maxValue = _bonusPrefab.LifeTime;
        _slider.value = _bonusPrefab.LifeTime;
        StartCoroutine(LivingBonus());
    }

    private IEnumerator LivingBonus()
    {
        for (float i = _slider.value; i > 0; i--)
        {
            _slider.value = i-1;
            yield return new WaitForSeconds(1);
        }
        gameObject.SetActive(false);
    }
}
