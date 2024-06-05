using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade;

    private void FixedUpdate()
    {

        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        Vector3 direcao = jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        if (distancia > 2.2)
        {
            GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position +
            direcao.normalized * velocidade * Time.deltaTime);

            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }

        void AtacaPersonagem ()
        {
            Time.timeScale = 0;
            jogador.GetComponent<ControlaPersonagem>().textoGameOver.SetActive(true);
            jogador.GetComponent<ControlaPersonagem>().vivo = false;
        }
    }
}