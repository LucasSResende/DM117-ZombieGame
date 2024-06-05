using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{

    public GameObject bala;
    public GameObject canoDaArma;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bala, canoDaArma.transform.position, canoDaArma.transform.rotation);
        }
    }
}
