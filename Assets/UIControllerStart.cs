using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControllerStart : MonoBehaviour
{
    public void OnClickButtonStart()
    {
        SceneManager.LoadScene("Fase1");
        ControlaZumbi.contaZumbi = 4;
    }
}
