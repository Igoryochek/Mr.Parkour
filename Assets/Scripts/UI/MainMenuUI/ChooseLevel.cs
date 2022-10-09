using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private GameObject _choosingLevelPanel;
    public void LoadLevelsChoosing()
    {
        _choosingLevelPanel.SetActive(true);
    }
}
