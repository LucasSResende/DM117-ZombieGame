using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerEnd : MonoBehaviour
{

    [SerializeField] Button startButtonEnd;
    // Start is called before the first frame update
    //void Start()
    //{
    //    startButton.onClick.AddListener(() => Debug.Log("Click Button"));
    //}

    public void OnClickButtonEnd()
    {
        Debug.Log("Click Button");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
