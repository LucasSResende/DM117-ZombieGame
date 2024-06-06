using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade;

    void FixedUpdate()
    {
        transform.position += transform.forward * velocidade * Time.deltaTime;
    }


    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
            ControlaZumbi.contaZumbi--;

            if (!gameObject.GetComponent<BoxCollider>())
            {
                gameObject.AddComponent<BoxCollider>();
            }
        }

        Destroy(gameObject);
    }
}