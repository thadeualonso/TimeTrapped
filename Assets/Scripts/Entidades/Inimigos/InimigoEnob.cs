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

            if (distancia > 0.7f)
            {
                transform.Translate(dirMovimento * speed * Time.deltaTime);
            }
            else
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

                    source.clip = attackSound;
                    source.Play();

                    target.gameObject.GetComponent<Personagem>().AplicarDano(dano);
                }

            }
        }
    }

    public override void Patrulhando()
    {
        if (timer <= 0f)
        {
            float randomX = UnityEngine.Random.Range(-1f, 1f);
            float randomY = UnityEngine.Random.Range(-1f, 1f);

            Vector2 heading = new Vector2(randomX, randomY);

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


}
