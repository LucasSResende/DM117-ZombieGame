using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaPersonagem : MonoBehaviour
{
    private Rigidbody rbPersonagem;
    private Animator animatorPersonagem;
    private float velocidade = 12;
    private Vector3 direcao;
    public LayerMask mascaraChao;
    public bool vivo = true;

    private void Start()
    {
        rbPersonagem = GetComponent<Rigidbody>();
        animatorPersonagem = GetComponent<Animator>();
        Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        direcao = new Vector3(moveX, 0, moveZ);

        if (direcao != Vector3.zero)
        {
            animatorPersonagem.SetBool("Andando", true);
        }
        else
        {
            animatorPersonagem.SetBool("Andando", false);

        }

        if (vivo == false)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    private void FixedUpdate()
    {
        rbPersonagem.MovePosition
            (rbPersonagem.position +
            (direcao * velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100))
        {
            Vector3 posicaoMiraPersonagem = impacto.point - transform.position;

            posicaoMiraPersonagem.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraPersonagem);

            rbPersonagem.MoveRotation(novaRotacao);
        }
    }

    public void VerificaContagemZumbis()
    {
        if (ControlaZumbi.contaZumbi <= 0)
        {
            SceneManager.LoadScene("Fase2");
        }
    }

}