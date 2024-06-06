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

        Vector3 miraPersonagem = Vector3.forward;
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100))
        {
            miraPersonagem = impacto.point;
        }
        transform.LookAt(new Vector3(miraPersonagem.x, transform.position.y, miraPersonagem.z));
    }

    public void VerificaContagemZumbis()
    {

        if (ControlaZumbi.contaZumbi <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Fase1")
            {
                SceneManager.LoadScene("Fase2");
                ControlaZumbi.contaZumbi = 5;
            }
            else if (SceneManager.GetActiveScene().name == "Fase2")
            {
                SceneManager.LoadScene("Finish");
            }
        }
    }
}