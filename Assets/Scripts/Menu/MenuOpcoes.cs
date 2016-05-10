using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuOpcoes : Menu
{
    public Image selecaoIcone;
    public Image teclado, joystick;
    public bool joystickSelecionado = false;
    public bool tecladoSelecionado = false;

    public override void ConfirmarSelecao()
    {
        if (Input.GetButtonDown("X"))
        {
            if (opcaoSelecionada == 0)
            {
                if (tecladoSelecionado)
                {
                    selecaoIcone.transform.position = joystick.transform.position;
                    joystickSelecionado = true;
                    tecladoSelecionado = false;
                }
                else
                {
                    selecaoIcone.transform.position = teclado.transform.position;
                    tecladoSelecionado = true;
                    joystickSelecionado = false;
                }
                
            }

            if (opcaoSelecionada == 1)
            {
                SceneManager.LoadScene("TelaInicial");
            }

        }
    }
}
