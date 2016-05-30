using UnityEngine;
using System.Collections;
using System;

public class Missel : Projetil {

    private ParticleSystem smokeParticle;

    void Awake()
    {
        smokeParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        Invoke("AtivarSmokeParticle", 0.25f);
        Invoke("Destruir", 5f);

        if (direcao == Direcoes.Right)      { transform.rotation = Quaternion.Euler(0f, 0f, -90f); }
        if (direcao == Direcoes.Left)       { transform.rotation = Quaternion.Euler(0f, 0f, 90f); }
        if (direcao == Direcoes.Up)         { transform.rotation = Quaternion.Euler(0f, 0f, 0f); }
        if (direcao == Direcoes.Down)       { transform.rotation = Quaternion.Euler(0f, 0f, 180f); }
        if (direcao == Direcoes.UpRight)    { transform.rotation = Quaternion.Euler(0f, 0f, 325f); }
        if (direcao == Direcoes.UpLeft)     { transform.rotation = Quaternion.Euler(0f, 0f, -325f); }
        if (direcao == Direcoes.DownRight)  { transform.rotation = Quaternion.Euler(0f, 0f, -135f); }
        if (direcao == Direcoes.DownLeft)   { transform.rotation = Quaternion.Euler(0f, 0f, 135f); }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
    }

    public override void OnTriggerEnter2D(Collider2D collider)
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
