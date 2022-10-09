using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettingsSign : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _settingsPanel.SetActive(true);
        }
    }
}
