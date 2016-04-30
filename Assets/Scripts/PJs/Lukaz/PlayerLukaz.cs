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
                    tiro1.dirY = 1f;
                }

                if (direcao == Direcoes.Down) {
                    tiro1.dirY = 1f;
                    tiro1.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }

                if (direcao == Direcoes.Right) {
                    tiro1.dirX = 1f;
                }

                if (direcao == Direcoes.Left) {
                    tiro1.dirX = -1f;
                }

                if (direcao == Direcoes.UpRight)
                {
                    tiro1.dirX = 1f;
                    tiro1.dirY = 1f;
                }

                if (direcao == Direcoes.DownRight)
                {
                    tiro1.dirX = 1f;
                    tiro1.dirY = -1f;
                }

                if (direcao == Direcoes.UpLeft)
                {
                    tiro1.dirX = -1f;
                    tiro1.dirY = 1f;
                }

                if (direcao == Direcoes.DownLeft)
                {
                    tiro1.dirX = -1f;
                    tiro1.dirY = -1f;
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
                /*Missel missel2 = (Missel)Instantiate(missel, transform.position, Quaternion.identity);
                Missel missel3 = (Missel)Instantiate(missel, transform.position, Quaternion.identity);*/

                if (direcao == Direcoes.Right)
                {
                    missel1.dirX = 1f;
                    missel1.dirY = 0f;
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, -90f);

                    /*missel2.dirX = 1f;
                    missel2.dirY = 0.5f;
                    missel2.transform.rotation = Quaternion.Euler(0f, 0f, 290f);

                    missel3.dirX = 1f;
                    missel3.dirY = -0.5f;
                    missel3.transform.rotation = Quaternion.Euler(0f, 0f, -120f);*/
                }

                if (direcao == Direcoes.Left)
                {
                    missel1.dirX = -1f;
                    missel1.dirY = 0f;
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

                    /*missel2.dirX = -1f;
                    missel2.dirY = 0.5f;
                    missel2.transform.rotation = Quaternion.Euler(0f, 0f, -290f);

                    missel3.dirX = -1f;
                    missel3.dirY = -0.5f;
                    missel3.transform.rotation = Quaternion.Euler(0f, 0f, 120f);*/
                }

                if (direcao == Direcoes.Up)
                {
                    missel1.dirX = 0f;
                    missel1.dirY = 1f;
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                    /*missel2.dirX = 0.5f;
                    missel2.dirY = 1f;
                    missel2.transform.rotation = Quaternion.Euler(0f, 0f, 340f);

                    missel3.dirX = -0.5f;
                    missel3.dirY = 1f;
                    missel3.transform.rotation = Quaternion.Euler(0f, 0f, -340f);*/
                }

                if (direcao == Direcoes.Down)
                {
                    missel1.dirX = 0f;
                    missel1.dirY = -1f;
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 180f);

                    /*missel2.dirX = 0.5f;
                    missel2.dirY = -1f;
                    missel2.transform.rotation = Quaternion.Euler(0f, 0f, 200f);

                    missel3.dirX = -0.5f;
                    missel3.dirY = -1f;
                    missel3.transform.rotation = Quaternion.Euler(0f, 0f, -200f);*/
                }

                #region Diagonais
                if (direcao == Direcoes.UpRight)
                {
                    missel1.dirX = 1f;
                    missel1.dirY = 1f;
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 316f);

                    /*missel2.dirX = 1f;
                    missel2.dirY = 0.5f;
                    missel2.transform.rotation = Quaternion.Euler(0f, 0f, 300f);

                    missel3.dirX = 1f;
                    missel3.dirY = 1.8f;
                    missel3.transform.rotation = Quaternion.Euler(0f, 0f, 300f);*/
                }

                if (direcao == Direcoes.DownRight)
                {
                    missel1.dirX = 1f;
                    missel1.dirY = -1f;
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, -120f);

                    /*missel2.dirX = 1f;
                    missel2.dirY = -0.5f;
                    missel2.transform.rotation = Quaternion.Euler(0f, 0f, -120f);

                    missel3.dirX = 1f;
                    missel3.dirY = -1.8f;
                    missel3.transform.rotation = Quaternion.Euler(0f, 0f, -120f);*/
                }

                if (direcao == Direcoes.DownLeft)
                {
                    missel1.dirX = -1f;
                    missel1.dirY = -1f;
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, 120f);

                    /*missel2.dirX = -1f;
                    missel2.dirY = -0.5f;
                    missel2.transform.rotation = Quaternion.Euler(0f, 0f, 120f);

                    missel3.dirX = -1f;
                    missel3.dirY = -1.8f;
                    missel3.transform.rotation = Quaternion.Euler(0f, 0f, 120f);*/
                }

                if (direcao == Direcoes.UpLeft)
                {
                    missel1.dirX = -1f;
                    missel1.dirY = 1f;
                    missel1.transform.rotation = Quaternion.Euler(0f, 0f, -300f);

                    /*missel2.dirX = -1f;
                    missel2.dirY = 0.5f;
                    missel2.transform.rotation = Quaternion.Euler(0f, 0f, -300f);

                    missel3.dirX = -1f;
                    missel3.dirY = 1.8f;
                    missel3.transform.rotation = Quaternion.Euler(0f, 0f, -300f);*/
                }
                #endregion
           }
        }
        #endregion

        //animator.SetBool("shooting", false);
    }

}
