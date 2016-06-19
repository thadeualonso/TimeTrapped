using UnityEngine;
using System.Collections;
using System;

public abstract class Inimigo : Humanoid
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

    [HideInInspector]
    public AudioSource source;
    public AudioClip attackSound;
    public AudioClip alertSound;

    public Transform target;

    void Awake()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case EnemyStates.Patrulhando:
                Patrulhando();
                break;
            case EnemyStates.Atacando:
                Atacando();
                break;
        }
    }

    public abstract void Patrulhando();
    public abstract void Atacando();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (source.isPlaying == false)
            {
                source.clip = alertSound;
                source.Play();
            }

            target = other.gameObject.transform;
            currentState = EnemyStates.Atacando;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
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
