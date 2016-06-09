using UnityEngine;
using System.Collections;
using System;

public abstract class Inimigo2 : Humanoid2
{
    [SerializeField]
    protected GameObject explosao;
    [SerializeField]
    protected GameObject projetil;
    [SerializeField]
    protected float attackCoolDown;
    protected float attackCounter;
    protected bool attacking;
    protected EnemyStates currentState;
    protected Animator anim;
    protected AudioSource source;
    protected AudioClip attackSound;
    protected AudioClip alertSound;

    void Awake()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
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
            if (source.isPlaying == false)
            {
                source.clip = alertSound;
                source.Play();
            }

            currentState = EnemyStates.Atacando;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
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
