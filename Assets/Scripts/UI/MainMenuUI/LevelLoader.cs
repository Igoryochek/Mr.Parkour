using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int levelNumber)
    {
        PlayerPrefs.SetInt("levelNumber", levelNumber);
        SceneManager.LoadScene(levelNumber);
    }

}
