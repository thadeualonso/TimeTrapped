using System.Collections;
using System;
using UnityEngine;

public class InimigoEnob : Inimigo
{
    public float timer;
    public Vector2 dirMovimento;

    public override void Atacando()
    {
        if (target)
        { 
            Vector2 heading = target.position - transform.position;

            float distancia = heading.magnitude;

            dirMovimento = heading / distancia;

            ChecaDirecao(dirMovimento.x, dirMovimento.y);

            if (distancia > 0.7f)
            {
                transform.Translate(dirMovimento * speed * Time.deltaTime);
            }
            else
            {
                attacking = true;
                anim.SetBool("attacking", attacking);

                if (attacking)
                {
                    if (attackCounter > 0)
                    {
                        attackCounter -= Time.deltaTime;
                    }
                    else
                    {
                        attacking = false;
                        anim.SetBool("attacking", attacking);
                    }
                }

                if (!attacking)
                {
                    attacking = true;
                    anim.SetBool("attacking", attacking);
                    attackCounter = attackCoolDown;

                    source.clip = attackSound;
                    source.Play();

                    target.gameObject.GetComponent<Personagem>().AplicarDano(dano);
                }

            }
        }
    }

    public override void Patrulhando()
    {
        anim.SetBool("attacking", false);

        if (timer <= 0f)
        {
            float randomX = UnityEngine.Random.Range(-1f, 1f);
            float randomY = UnityEngine.Random.Range(-1f, 1f);

            Vector2 heading = new Vector2(randomX, randomY);

            ChecaDirecao(randomX, randomY);

            float distancia = heading.magnitude;

            dirMovimento = heading / distancia;

            timer = 1f;
        }
        else
        {
            transform.Translate(dirMovimento * 0.5f * Time.deltaTime);
            timer -= Time.deltaTime;
        }
    }


    void ChecaDirecao(float x, float y)
    {
        if(x > 0.1f)
        {
            anim.SetFloat("SpeedX", 1f);
        }

        if (x < -0.1f)
        {
            anim.SetFloat("SpeedX", -1f);
        }

        if (y > 0.1f)
        {
            anim.SetFloat("SpeedY", 1f);
        }

        if (y < -0.1f)
        {
            anim.SetFloat("SpeedY", -1f);
        }


        if (x != 0f || y != 0f)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

}
