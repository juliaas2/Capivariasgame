using UnityEngine;

public class Inimigo_BlocoQueCai : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float gravidade;
    [SerializeField] private float velocidadeDeSubida;
    [SerializeField] private float tempoMaximoParaSubir;
    [SerializeField] private float tempoNoTopo;

    [SerializeField] private AudioClip somImpacto; // som da batida
    private AudioSource audioSource;

    private float tempoAtualParaSubir;
    private float tempoAtualNoTopo;

    private Vector3 posicaoInicial;
    private bool podeCair;
    private bool caiu;
    private bool esperandoNoTopo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        podeCair = false;
        caiu = false;
        esperandoNoTopo = false;

        rb.gravityScale = 0f;
        posicaoInicial = transform.position;

        tempoAtualParaSubir = tempoMaximoParaSubir;
        tempoAtualNoTopo = tempoNoTopo;
    }

    void Update()
    {
        RodarCronometro();
    }

    private void RodarCronometro()
    {
        if (caiu)
        {
            tempoAtualParaSubir -= Time.deltaTime;
            if (tempoAtualParaSubir <= 0)
            {
                caiu = false;
                rb.gravityScale = 0f;
                tempoAtualParaSubir = tempoMaximoParaSubir;
            }
        }
        else if (!esperandoNoTopo)
        {
            if (transform.position != posicaoInicial)
            {
                transform.position = Vector3.MoveTowards(transform.position, posicaoInicial, velocidadeDeSubida * Time.deltaTime);
                podeCair = false;
            }
            else
            {
                esperandoNoTopo = true;
                tempoAtualNoTopo = tempoNoTopo;
            }
        }
        else
        {
            tempoAtualNoTopo -= Time.deltaTime;
            if (tempoAtualNoTopo <= 0f)
            {
                esperandoNoTopo = false;
                podeCair = true;
                AtivarGravidade();
            }
        }
    }

    public void AtivarGravidade()
    {
        if (podeCair)
        {
            caiu = true;
            rb.gravityScale = gravidade;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (caiu)
        {
            string nome = collision.collider.name;
            if (nome == "Jungle_tile_11_0 (13)" || nome == "Jungle_tile_11_0 (18)")
            {
                if (somImpacto != null)
                {
                    audioSource.PlayOneShot(somImpacto);
                }
            }
        }
    }
}