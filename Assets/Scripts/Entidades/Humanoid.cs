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
    [HideInInspector]
    //TODO Mudar tipo de volta para 'GameManager'
    public GameManagerTeste gameManager;
    [HideInInspector]
    public InputManager inputManager;

    public void Awake()
    {
        ProcurarManagersNaCena();

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

            if (gameObject.tag == "Player")
            {
                gameManager.RemoverDaEquipe();
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

    void ProcurarManagersNaCena()
    {
        //TODO: Alterar o tipo de volta para 'GameManager'   
        if(GameObject.FindObjectOfType<GameManagerTeste>() != null)
        {
            gameManager = GameObject.FindObjectOfType<GameManagerTeste>();
        }
        else
        {
            Debug.Log("Humanoid: GameManager não encontrado");
        }

        if (GameObject.FindObjectOfType<InputManager>() != null)
        {
            inputManager = GameObject.FindObjectOfType<InputManager>();
        }
        else
        {
            Debug.Log("Humanoid: InputManager não encontrado");
        }

        if (GameObject.FindObjectOfType<EnemyManager>() != null)
        {
            enemyManager = GameObject.FindObjectOfType<EnemyManager>();
        }
        else
        {
            Debug.Log("Humanoid: EnemyManager não encontrado");
        }
    }
}
