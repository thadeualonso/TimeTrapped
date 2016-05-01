using UnityEngine;
using System.Collections;
using System;

public abstract class Humanoid : MonoBehaviour {

    public Direcoes direcao;
    public NiveisTerrenos nivelTerreno;
    public int hp;
    public int hpMax;
    public int dano;
    public float speed;
    public Animator animator;
    public Collider2D collider2D;

    void Awake()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        hpMax = hp;
    }

    void Update()
    {
        Mover();

        Ataque();

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        ChecaDirecao();
    }

    void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Nivel Superior")
        {
            nivelTerreno = NiveisTerrenos.Superior;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Nivel Superior")
        {
            nivelTerreno = NiveisTerrenos.Chao;
        }
    }

    // Implementar o ataque
    public abstract void Ataque();

    public abstract void Mover();

    public abstract void ChecaDirecao();

    public void AplicarDano(int dano)
    {
        hp -= dano;
    }
}
