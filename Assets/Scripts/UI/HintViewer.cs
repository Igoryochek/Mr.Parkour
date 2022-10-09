using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintViewer : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
