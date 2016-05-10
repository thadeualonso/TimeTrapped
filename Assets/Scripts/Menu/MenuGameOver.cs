using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGameOver : Menu {

    public override void ConfirmarSelecao()
    {
        if (Input.GetButtonDown("X"))
        {
            if(opcaoSelecionada == 0)
            {
                SceneManager.LoadScene("TelaInicial");
            }

            if (opcaoSelecionada == 1)
            {
                Application.Quit();
            }
        }
    }

}
