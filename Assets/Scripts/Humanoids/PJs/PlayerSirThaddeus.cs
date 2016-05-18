using UnityEngine;
using System.Collections;

public class PlayerSirThaddeus : Personagem {

    void FixedUpdate()
    {
        animator.SetBool("attacking", false);
    }

    public override void Ataque()
    {
        if (Input.GetButtonDown("A"))
        {
            animator.SetBool("attacking", true);
        }
    }

}
