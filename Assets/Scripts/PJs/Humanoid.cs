using UnityEngine;
using System.Collections;
using System;

public abstract class Humanoid : MonoBehaviour {

    public Direcoes direcao;
    public int hp;
    public int hpMax;
    public int ataque;
    public float speed;
    public float InputX;
    public float InputY;
    public Tiro tiro;
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        hpMax = hp;
    }

    void Update()
    {
        Mover();

        Ataque();

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

        ChecaDirecao();
    }

    void FixedUpdate()
    {
        
    }

    // Implementar o ataque
    public abstract void Ataque();

    public abstract void Mover();

    public abstract void ChecaDirecao();
}
