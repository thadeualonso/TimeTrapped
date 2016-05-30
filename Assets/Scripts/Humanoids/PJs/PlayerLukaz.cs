using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLukaz : Personagem {

    public override void Ataque()
    {
        base.Ataque();

        if (Input.GetButtonDown("A") && !isShooting)
        {
            if (canShootNormal)
            {
                sourceAudio.clip = soundEffects[0];
                sourceAudio.Play();

                coolDownAtaqueNormal += delayAtaqueNormal;

                Tiro tiro1 = (Tiro)Instantiate(projetilNormal, transform.position, Quaternion.identity);
            }
        }

        if (Input.GetButtonDown("X") && !isShooting)
        {
            if (canShootEspecial)
            {
                isShooting = true;
                shootingTimer = shootingCD;

                sourceAudio.clip = soundEffects[1];
                sourceAudio.Play();

                animator.SetBool("shooting", true);

                coolDownAtaqueEspecial += delayAtaqueEspecial;

                //Vector3 misselPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3f);

                Missel missel1 = (Missel) Instantiate(projetilEspecial, transform.position, Quaternion.identity);
                missel1.direcao = direcao;
           }
        }
        animator.SetBool("shooting", isShooting);

    }

}
