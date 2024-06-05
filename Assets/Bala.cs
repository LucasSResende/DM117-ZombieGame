using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade;
    private Rigidbody rbBala;

    private void Start()
    {
        rbBala = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rbBala.MovePosition(
        rbBala.position + 
        transform.forward * velocidade * Time.deltaTime);
    }


    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
        }

        Destroy(gameObject);
    }
}
