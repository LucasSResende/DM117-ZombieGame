using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlaPersonagem : MonoBehaviour
{
    [SerializeField] float velocidade;
    Vector3 direcao;
    public LayerMask mascaraChao;
    public GameObject textoGameOver;
    public bool vivo = true;

    private void Start()
    {
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
            GetComponent<Animator>().SetBool("Andando", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Andando", false);

        }

        if (vivo == false)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Fase1");
            }
        }

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position +
            (direcao * velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100))
        {
            Vector3 posicaoMiraPersonagem = impacto.point - transform.position;

            posicaoMiraPersonagem.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraPersonagem);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }
}