using UnityEngine;
using System.Collections;

public class Missel : MonoBehaviour {

    public float velocidade;
    public Direcoes direcao;
    public NiveisTerrenos nivelTerreno;
    public float dirX;
    public float dirY;
    public int dano;
    public GameObject explosao;

    private ParticleSystem smokeParticle;

    void Awake()
    {
        smokeParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        Invoke("AtivarSmokeParticle", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Inimigo" && collider.GetComponent<Humanoid>().nivelTerreno == nivelTerreno)
        {
            Destroy(gameObject);
            collider.SendMessageUpwards("AplicarDano", dano);
            Instantiate(explosao, collider.transform.position, Quaternion.identity);
        }

        if (collider.gameObject.tag == "Limites Mundo")
        {
            Destroy(gameObject);
        }
    }

    void AtivarSmokeParticle()
    {
        Debug.Log("Ativar smoke particle chamada");
        smokeParticle.Play();
    }
}
