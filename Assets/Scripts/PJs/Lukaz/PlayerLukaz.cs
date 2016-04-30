using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLukaz : Personagem {

    public Missel missel;
    public float coolDownMissel;
    public float coolDownTiro;

    private bool canShootMissel;
    private bool canShootTiro;

    void FixedUpdate()
    {
        if (coolDownTiro >= 0.1f)
        {
            coolDownTiro -= Time.deltaTime;
            canShootTiro = false;
        }
        else
        {
            canShootTiro = true;
        }


        if (coolDownMissel >= 0.1f)
        {
            coolDownMissel -= Time.deltaTime;
            canShootMissel = false;
        }
        else
        {
            canShootMissel = true;
        }
    }

    public override void Ataque()
    {
        missel.dano = dano * 5;
        tiro.dano = dano;

        tiro.direcao = direcao;
        tiro.nivelTerreno = nivelTerreno;

        missel.direcao = direcao;
        missel.nivelTerreno = NiveisTerrenos.Superior;

        #region Ataque normal
        if (Input.GetButtonDown("X"))
        {
            if (canShootTiro)
            {
                //animator.SetBool("shooting", true);

                coolDownTiro += 0.3f;

                Tiro tiro1 = (Tiro)Instantiate(tiro, transform.position, Quaternion.identity);

                if (direcao == Direcoes.Up) {
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }

                if (direcao == Direcoes.Down) {
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }

                if (direcao == Direcoes.Right) {
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                }

                if (direcao == Direcoes.Left) {
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                }

                if (direcao == Direcoes.UpRight)
                {
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, 325f);
                }

                if (direcao == Direcoes.UpLeft)
                {
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, -325f);
                }

                if (direcao == Direcoes.DownRight)
                {
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, -135f);
                }

                if (direcao == Direcoes.DownLeft)
                {
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, 135f);
                }
            }

        }
        #endregion

        #region Ataque especial
        if (Input.GetButtonDown("Quadrado"))
        {
            if (canShootMissel)
            {
                coolDownMissel += 3f;

                Vector3 misselPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3f);

                Missel missel1 = (Missel)Instantiate(missel, misselPos, Quaternion.identity);

                if (direcao == Direcoes.Right)
                {
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                }

                if (direcao == Direcoes.Left)
                {
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                }

                if (direcao == Direcoes.Up)
                {
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }

                if (direcao == Direcoes.Down)
                {
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }

                #region Diagonais
                if (direcao == Direcoes.UpRight)
                {
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 325f);
                }

                if (direcao == Direcoes.UpLeft)
                {
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, -325f);
                }

                if (direcao == Direcoes.DownRight)
                {
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, -135f);
                }

                if (direcao == Direcoes.DownLeft)
                {
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 135f);
                }

                #endregion
           }
        }
        #endregion

        //animator.SetBool("shooting", false);
    }

}
