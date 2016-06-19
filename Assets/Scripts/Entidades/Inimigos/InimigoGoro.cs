using UnityEngine;
using System.Collections;
using System;

public class InimigoGoro : Inimigo {

    public override void Patrulhando()
    { 
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
                source.clip = attackSound;
                source.Play();
            }
        }

        anim.SetBool("attacking", attacking);
    }

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

            Instantiate(projetil, transform.position, Quaternion.Euler(0f, 0f, -180f));
            source.clip = attackSound;
            source.Play();
        }

        anim.SetBool("attacking", attacking);
    }


}
