using UnityEngine;
using System.Collections;
using System;

public class EnemyTaka : Enemy
{
    public override void Atacando()
    {
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

            if (direcao == Direcoes.Left)
            {
                Debug.Log("Instancia Left");
                GameObject lanca = (GameObject) Instantiate(projetil, transform.position, Quaternion.Euler(0f, 0f, 90f));
                lanca.GetComponent<TakaLanca>().direcao = direcao;
                source.clip = attackSound;
                source.Play();
            }

            if (direcao == Direcoes.Right)
            {
                Debug.Log("Instancia Right");
                GameObject lanca = (GameObject) Instantiate(projetil, transform.position, Quaternion.Euler(0f, 0f, -90f));
                lanca.GetComponent<TakaLanca>().direcao = direcao;
                source.clip = attackSound;
                source.Play();
            }

        }

        anim.SetBool("attacking", attacking);
    }

    public override void Patrulhando()
    {
        if (direcao == Direcoes.Left)
        {
            anim.SetFloat("SpeedX", -1f);
        }

        if (direcao == Direcoes.Right)
        {
            anim.SetFloat("SpeedX", 1f);
        }

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

                if (direcao == Direcoes.Left)
                {
                    GameObject lanca = (GameObject)Instantiate(projetil, transform.position, Quaternion.Euler(0f, 0f, 90f));
                    lanca.GetComponent<TakaLanca>().direcao = direcao;
                    source.clip = attackSound;
                    source.Play();
                }

                if (direcao == Direcoes.Right)
                {
                    GameObject lanca = (GameObject)Instantiate(projetil, transform.position, Quaternion.Euler(0f, 0f, -90f));
                    lanca.GetComponent<TakaLanca>().direcao = direcao;
                    source.clip = attackSound;
                    source.Play();
                }

            }
        }

        anim.SetBool("attacking", attacking);
    }
}
