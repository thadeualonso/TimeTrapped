using UnityEngine;
using System.Collections;

public class Missel : MonoBehaviour {

    public float velocidade;
    public Direcoes direcao;
    public NiveisTerrenos nivelTerreno;
    public float dirX;
    public float dirY;

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
        switch (direcao)
        {
            case Direcoes.Right:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.Left:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.Up:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.Down:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.UpRight:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.UpLeft:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.DownRight:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
            case Direcoes.DownLeft:
                transform.Translate(dirX * velocidade * Time.deltaTime, dirY * velocidade * Time.deltaTime, 0.0f, Space.World);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Colisao: Trigger");

        if (collider.gameObject.tag == "Inimigo" && collider.GetComponent<Humanoid>().nivelTerreno == nivelTerreno)
        {
            Destroy(gameObject);
            Debug.Log(collider.GetComponent<Humanoid>().nivelTerreno);
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
