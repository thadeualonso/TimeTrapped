using UnityEngine;
using System.Collections;
using System;

public abstract class Humanoid2 : MonoBehaviour
{
    [SerializeField]
    protected Direcoes direcao;
    private NiveisTerrenos nivelTerreno;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int hpMax;
    [SerializeField]
    private int dano;
    private float speed;
    private Animator animator;
    private Collider2D collider2D;
    private EnemyManager enemyManager;
    private GameManager gameManager;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
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
                gameManager.Invoke("ChamaGameOver", 2f);
            }
            else if (gameObject.tag == "Player")
            {
                GameManager.equipeP1--;
                gameManager.pjsMortos = true;
                gameManager.arrayPJs[0] = null;
            }
        }

        ChecaDirecao();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Nivel Superior")
        {
            nivelTerreno = NiveisTerrenos.Superior;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
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
