using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade = 0.8f;
    private Rigidbody rbZumbi;
    private Animator animatorZumbi;

    private void Start()
    {
        rbZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();
        int contaZumbi = 4;
    }

    private void FixedUpdate()
    {

        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        Vector3 direcao = jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rbZumbi.MoveRotation(novaRotacao);

        if (distancia > 2.2)
        {
            rbZumbi.MovePosition(
                rbZumbi.position +
                direcao.normalized * velocidade * Time.deltaTime);

            animatorZumbi.SetBool("Atacando", false);
        }
        else
        {
            animatorZumbi.SetBool("Atacando", true);
        }

    }
    void AtacaPersonagem()
    {
        Time.timeScale = 0;
        jogador.GetComponent<ControlaPersonagem>().vivo = false;
    }
}