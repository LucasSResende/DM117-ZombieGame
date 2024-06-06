using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerReiniciar: MonoBehaviour
{
    public void OnClickButtonStart()
    {
        SceneManager.LoadScene("Start");
    }
}

