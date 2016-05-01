using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Personagem : Humanoid
{
    public Tiro tiro;
    public float InputX;
    public float InputY;
    public int danoAtaqueNormal;
    public int danoAtaqueEspecial;

    public override void Ataque()
    {
        
    }

    // Chamar no Update
    public override void Mover()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("SpeedX", InputX);
        animator.SetFloat("SpeedY", InputY);

        Vector3 movement = new Vector3(InputX * speed, InputY * speed, 0.0f);

        movement *= Time.deltaTime;

        //gameObject.transform.Translate(movement);

        transform.Translate(movement);
    }

    // Chamar no FixedUpdate
    public override void ChecaDirecao()
    {
        float lastInputX = Input.GetAxisRaw("Horizontal");
        float lastInputY = Input.GetAxisRaw("Vertical");

        if (lastInputX != 0 || lastInputY != 0)
        {
            animator.SetBool("walking", true);

            #region Checa o eixo X
            if (lastInputX > 0)
            {
                animator.SetFloat("LastX", 1f);
                direcao = Direcoes.Right;
            }
            else if (lastInputX < 0)
            {
                animator.SetFloat("LastX", -1f);
                direcao = Direcoes.Left;
            }
            else
            {
                animator.SetFloat("LastX", 0f);
            }
            #endregion

            #region Checa o eixo Y e diagonais
            if (lastInputY > 0)
            {
                animator.SetFloat("LastY", 1f);
                direcao = Direcoes.Up;

                if (lastInputX > 0)
                {
                    direcao = Direcoes.UpRight;
                }
                else if (lastInputX < 0)
                {
                    direcao = Direcoes.UpLeft;
                }
            }
            else if (lastInputY < 0)
            {
                animator.SetFloat("LastY", -1f);
                direcao = Direcoes.Down;

                if (lastInputX > 0)
                {
                    direcao = Direcoes.DownRight;
                }
                else if (lastInputX < 0)
                {
                    direcao = Direcoes.DownLeft;
                }
            }
            else
            {
                animator.SetFloat("LastY", 0f);
            }
        }
        else
        {
            animator.SetBool("walking", false);
        }
        #endregion
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
