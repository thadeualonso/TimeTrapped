using UnityEngine;
using System.Collections;

public class PlayerWagnur : Personagem {

    public override void Ataque()
    {
        base.Ataque();

        if (Input.GetButtonDown("A") && !isShooting)
        {
            if (canShootNormal)
            {
                projetilNormal.direcao = direcao;

                coolDownAtaqueNormal += delayAtaqueNormal;

                WagnurLanca lanca = (WagnurLanca)Instantiate(projetilNormal, transform.position, Quaternion.identity);
            }
            //TODO: usar esse codigo em alguma coisa irada
            //projetil = gameObject.AddComponent<WagnurLanca>();

        }

        if (Input.GetButtonDown("X") && !isShooting)
        {
            if (canShootEspecial)
            {
                projetilEspecial.direcao = direcao;

                coolDownAtaqueEspecial += delayAtaqueEspecial;

                WagnurToraMadeira tora = (WagnurToraMadeira)Instantiate(projetilEspecial, transform.position, Quaternion.identity);
            }
        }

    }

}
