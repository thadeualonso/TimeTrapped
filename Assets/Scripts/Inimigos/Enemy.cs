using UnityEngine;
using System.Collections;
using System;

public abstract class Enemy : Humanoid
{
    public GameObject explosao;
    public GameObject projetil;

    public float attackCoolDown;
    public float attackCounter;
    public bool attacking;

    [HideInInspector]
    public EnemyStates currentState;
    [HideInInspector]
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case EnemyStates.Patrulhando: Patrulhando(); break;
            case EnemyStates.Atacando: Atacando(); break;
        }
    }

    public abstract void Patrulhando();
    public abstract void Atacando();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player no campo de visao");
            currentState = EnemyStates.Atacando;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player saiu do campo de visao");
            currentState = EnemyStates.Patrulhando;
        }
    }

    public override void Ataque()
    {
        
    }

    public override void ChecaDirecao()
    {
        
    }

    public override void Mover()
    {
        
    }
}
