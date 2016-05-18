using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Personagem : Humanoid
{
    public Projetil tiro;
    public int danoAtaqueNormal;
    public int danoAtaqueEspecial;

    private float horizontal;
    private float vertical;

    [HideInInspector]
    public AudioSource sourceAudio;
    public AudioClip[] soundEffects;

    public InputManager inputManager;

    void Start()
    {
        if (FindObjectOfType<InputManager>() != null)
        {
            inputManager = FindObjectOfType<InputManager>();
        }
        else
        {
            Debug.LogWarning("InputManager não encontrado");
        }
    }

    public override void Ataque()
    {
        
    }

    // Chamar no Update
    public override void Mover()
    {
        horizontal = inputManager.horizontal;
        vertical = inputManager.vertical;

        animator.SetFloat("SpeedX", horizontal);
        animator.SetFloat("SpeedY", vertical);

        Vector3 movement = new Vector3(horizontal * speed, vertical * speed, 0.0f);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    // Chamar no FixedUpdate
    public override void ChecaDirecao()
    {
        float lastInputX = horizontal;
        float lastInputY = vertical;

        if (lastInputX != 0f || lastInputY != 0f)
        {
            animator.SetBool("walking", true);

            #region Checa o eixo X
            if (lastInputX > 0.1f)
            {
                direcao = Direcoes.Right;
            }
            else if (lastInputX < 0.1f)
            {
                direcao = Direcoes.Left;
            }
            #endregion

            #region Checa o eixo Y e diagonais
            if (lastInputY > 0.1f)
            {
                direcao = Direcoes.Up;

                if (lastInputX > 0.1f)
                {
                    direcao = Direcoes.UpRight;
                }
                else if (lastInputX < 0f)
                {
                    direcao = Direcoes.UpLeft;
                }
            }
            else if (lastInputY < 0f)
            {
                direcao = Direcoes.Down;

                if (lastInputX > 0f)
                {
                    direcao = Direcoes.DownRight;
                }
                else if (lastInputX < 0f)
                {
                    direcao = Direcoes.DownLeft;
                }
            }
            #endregion

            animator.SetFloat("LastX", horizontal);
            animator.SetFloat("LastY", vertical);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TiroInimigo"))
        {
            this.hp--;
            SceneManager.LoadScene("TelaGameOver");
        }
    }

}
