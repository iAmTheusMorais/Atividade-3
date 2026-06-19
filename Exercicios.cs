using UnityEngine;

public class Exercicios : MonoBehaviour
{
    // Variáveis Globais
    bool podeSeMover = true;
    public float velocidade = 5f; 
    float horizontal;
    float vertical;
    float multiplicadortempo = 1f;
    float temposobrevivido = 0f; 

    void Start()
    {
        //AT1
        transform.position = new Vector3(0, 5, 0);

        //AT2
        transform.localScale = new Vector3(2, 2, 2);

        //AT3
        transform.position = Vector3.up;

        //AT5
        Vector3 Jogador = new Vector3(2, 2, 3);
        Vector3 posInimigo = new Vector3(2, 4, 1);
        float distancia = Vector3.Distance(Jogador, posInimigo);
        Debug.Log("Distância entre jogador e inimigo: " + distancia);
    }

    void Update()
    {
        //AT4
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector3.zero;
        }

        //AT6
        float movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        if (movimentoHorizontal > 0)
        {
            Debug.Log("Direita");
        }   
        else if (movimentoHorizontal < 0)
        {
            Debug.Log("Esquerda");
        }
        else
        {
            Debug.Log("Parado");
        }

        //AT7
        vertical = Input.GetAxis("Vertical");
        Debug.Log("Vertical " + vertical);

        //AT8
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            transform.Translate(Vector3.up);
        }

        //AT9
        if (Input.GetKeyDown(KeyCode.F))
        {
            podeSeMover = false;
            Debug.Log("Movimentação travada");
        }
        if (podeSeMover)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            Debug.Log("H" + horizontal + " | V" + vertical);
        }
        if (!podeSeMover) return;

        //AT12
        if (Input.GetKey(KeyCode.LeftShift))
        {
            multiplicadortempo = 0.5f;
        }
        else
        {
            multiplicadortempo = 1f;
        }

        //AT10 e 11
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 direcao = new Vector3(horizontal, 0, vertical);
        transform.Translate(direcao * velocidade * multiplicadortempo * Time.deltaTime);

        //AT13
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Translate(direcao * 3f);
        }

        //AT14
        temposobrevivido += Time.deltaTime;
        Debug.Log("Tempo Sobrevivido: " + temposobrevivido.ToString("F2"));

        //AT15
        if (transform.position.x > 5f)
        {
            velocidade = -Mathf.Abs(velocidade);
        }
        else if (transform.position.x < -5f)
        {
            velocidade = Mathf.Abs(velocidade);
        }
    }
}