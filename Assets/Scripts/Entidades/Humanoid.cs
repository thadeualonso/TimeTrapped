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

    [HideInInspector]
    public Animator animator;

    [HideInInspector]
    public Collider2D collider2D;
    [HideInInspector]
    public EnemyManager enemyManager;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        hp = hpMax;
    }

    public void Update()
    {
        Mover();

        Ataque();

        if (hp <= 0)
        {
            Destroy(gameObject);

            if (gameObject.tag == "Player" && GameManager.equipeP1 <= 0)
            {
                FindObjectOfType<GameManager>().Invoke("ChamaGameOver", 2f);
            }
            else if (gameObject.tag == "Player")
            {
                GameManager.equipeP1--;
                FindObjectOfType<GameManager>().pjsMortos = true;
                FindObjectOfType<GameManager>().arrayPJs[0] = null;
            }
        }

        ChecaDirecao();
    }

    public void FixedUpdate()
    {
        
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
