﻿using UnityEngine;
using System.Collections;
using System;

public abstract class Humanoid : MonoBehaviour {

    public Direcoes direcao;
    public NiveisTerrenos nivelTerreno;
    public int hp;
    public int hpMax;

    [HideInInspector]
    public int dano;
    public float speed;

    [HideInInspector]
    public Animator animator;

    [HideInInspector]
    public Collider2D collider2D;
    public EnemyManager enemyManager;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        hpMax = hp;
    }

    public void Update()
    {
        Mover();

        Ataque();

        if (hp <= 0)
        {
            Destroy(gameObject);

            if (gameObject.tag == "Player")
            {
                FindObjectOfType<GameManager>().Invoke("ChamaGameOver", 2f);
            }
        }

        ChecaDirecao();
    }

    public void FixedUpdate()
    {
        
    }

    public void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Nivel Superior")
        {
            nivelTerreno = NiveisTerrenos.Superior;
        }
    }

    public void OnCollisionExit2D (Collision2D other)
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