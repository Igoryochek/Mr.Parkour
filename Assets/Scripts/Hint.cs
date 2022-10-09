using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] private HintViewer _hintViewer;

    private bool _firstTime = true;

    public void StartHint()
    {
        if (_firstTime)
        {
            _hintViewer.gameObject.SetActive(true);
            _firstTime = false;
        }
    }
}
