using UnityEngine;
using System.Collections;

public class PlayerLukaz : Personagem {

    public override void Ataque()
    {
        tiro.direcao = direcao;

        #region Ataque normal
        if (Input.GetButtonDown("X"))
        {
            Debug.Log("Apertando O");

            Tiro tiro1 = (Tiro)Instantiate(tiro, transform.position, Quaternion.identity);

            if (direcao == Direcoes.Up) { tiro1.dirY = 1f; }
            if (direcao == Direcoes.Down) { tiro1.dirY = -1f; }
            if (direcao == Direcoes.Right) { tiro1.dirX = 1f; }
            if (direcao == Direcoes.Left) { tiro1.dirX = -1f; }

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
        #endregion

        #region Ataque especial
        if (Input.GetButtonDown("Quadrado"))
        {
            Tiro tiro1 = (Tiro)Instantiate(tiro, transform.position, Quaternion.identity);
            Tiro tiro2 = (Tiro)Instantiate(tiro, transform.position, Quaternion.identity);
            Tiro tiro3 = (Tiro)Instantiate(tiro, transform.position, Quaternion.identity);

            if (direcao == Direcoes.Right)
            {
                tiro1.dirX = 1f;
                tiro1.dirY = 0f;

                tiro2.dirX = 1f;
                tiro2.dirY = 0.5f;

                tiro3.dirX = 1f;
                tiro3.dirY = -0.5f;
            }

            if (direcao == Direcoes.Left)
            {
                tiro1.dirX = -1f;
                tiro1.dirY = 0f;

                tiro2.dirX = -1f;
                tiro2.dirY = 0.5f;

                tiro3.dirX = -1f;
                tiro3.dirY = -0.5f;
            }

            if (direcao == Direcoes.Up)
            {
                tiro1.dirX = 0f;
                tiro1.dirY = 1f;

                tiro2.dirX = 0.5f;
                tiro2.dirY = 1f;

                tiro3.dirX = -0.5f;
                tiro3.dirY = 1f;
            }

            if (direcao == Direcoes.Down)
            {
                tiro1.dirX = 0f;
                tiro1.dirY = -1f;

                tiro2.dirX = 0.5f;
                tiro2.dirY = -1f;

                tiro3.dirX = -0.5f;
                tiro3.dirY = -1f;
            }

            #region Diagonais
            if (direcao == Direcoes.UpRight)
            {
                tiro1.dirX = 1f;
                tiro1.dirY = 1f;

                tiro2.dirX = 1f;
                tiro2.dirY = 0.5f;

                tiro3.dirX = 1f;
                tiro3.dirY = 1.8f;
            }

            if (direcao == Direcoes.DownRight)
            {
                tiro1.dirX = 1f;
                tiro1.dirY = -1f;

                tiro2.dirX = 1f;
                tiro2.dirY = -0.5f;

                tiro3.dirX = 1f;
                tiro3.dirY = -1.8f;
            }

            if (direcao == Direcoes.DownLeft)
            {
                tiro1.dirX = -1f;
                tiro1.dirY = -1f;

                tiro2.dirX = -1f;
                tiro2.dirY = -0.5f;

                tiro3.dirX = -1f;
                tiro3.dirY = -1.8f;
            }

            if (direcao == Direcoes.UpLeft)
            {
                tiro1.dirX = -1f;
                tiro1.dirY = 1f;

                tiro2.dirX = -1f;
                tiro2.dirY = 0.5f;

                tiro3.dirX = -1f;
                tiro3.dirY = 1.8f;
            }
            #endregion

        }
        #endregion

    }
}
