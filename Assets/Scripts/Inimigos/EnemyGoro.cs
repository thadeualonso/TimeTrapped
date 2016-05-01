using UnityEngine;
using System.Collections;
using System;

public class EnemyGoro : Humanoid {

    public float moveX;
    public float moveY;
    public GameObject projetil;

    public float attackCoolDown;
    public float attackCounter;
    public bool attacking;

    private CircleCollider2D visao;
    private EnemyStates currentState;
    private Animator anim;

    void Awake()
    {
        visao = GetComponentInChildren<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyStates.Patrulhando: Patrulhando(); break;
            case EnemyStates.Atacando   : Atacando();    break; 
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        base.OnTriggerEnter2D(other);

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
            Debug.Log("Player no campo de visao");
            currentState = EnemyStates.Patrulhando;
        }

    }

    void Patrulhando()
    {
        Debug.Log("Patrulhando");

        if (attacking)
        {
            if (attackCounter > 0)
            {
                attackCounter -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackCounter = attackCoolDown;
                Instantiate(projetil, transform.position, Quaternion.Euler(0f, 0f, -180f));
            }
        }

        //attacking = false;
        //attackCounter = 0;
        anim.SetBool("attacking", attacking);
    }

    void Atacando()
    {
        Debug.Log("Atacando");

        attacking = true;

        if (attacking)
        {
            if (attackCounter > 0)
            {
                attackCounter -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }

        if (!attacking)
        {
            attacking = true;
            attackCounter = attackCoolDown;

            Instantiate(projetil, transform.position, Quaternion.Euler(0f, 0f, -180f));
        }

        anim.SetBool("attacking", attacking);
    }

    public override void Ataque()
    {
        
    }

    public override void Mover()
    {
        
    }

    public override void ChecaDirecao()
    {
        
    }
}
