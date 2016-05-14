using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuOpcoes : Menu
{
    public Image selecaoIcone;
    public Image teclado, joystick;
    public bool joypadSelecionado;
    public bool keyboardSelecionado;

    public override void ConfirmarSelecao()
    {
        if (Input.GetButtonDown("A"))
        {
            if (opcaoSelecionada == 0)
            {
                if (keyboardSelecionado)
                {
                    selecaoIcone.transform.position = joystick.transform.position;
                    /* joypadSelecionado = true;
                     keyboardSelecionado = false; */

                    inputManager.joystick = true;
                    inputManager.keyboard = false;
                }
                else
                {
                    selecaoIcone.transform.position = teclado.transform.position;
                   /* keyboardSelecionado = true;
                    joypadSelecionado = false;*/

                    inputManager.joystick = false;
                    inputManager.keyboard = true;
                }
                
            }

            if (opcaoSelecionada == 1)
            {
                SceneManager.LoadScene("TelaInicial");
            }

        }
    }
}
