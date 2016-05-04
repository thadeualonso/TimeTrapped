using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Image selecao;
    public Text txtControles;
    public Text txtVoltar;
    public string[] menuOpcoes;
    public int opcaoSelecionada;

    private bool stickInUse = false;

    /*void Awake()
    {
        menuOpcoes[0] = "Controles";
        menuOpcoes[1] = "Voltar";

        opcaoSelecionada = 0;
    }*/

    void Update()
    {
        MoverSelecao();
        ConfirmarSelecao();
    }

    int MenuSelecao(string[] menuItems, int itemSelecionado, string direcao)
    {
        if (direcao == "cima")
        {
            if (itemSelecionado == 0)
            {
                itemSelecionado = menuItems.Length - 1;
            }
            else
            {
                itemSelecionado -= 1;
            }
        }

        if (direcao == "baixo")
        {
            if (itemSelecionado == menuItems.Length - 1)
            {
                itemSelecionado = 0;
            }
            else
            {
                itemSelecionado += 1;
            }
        }

        return itemSelecionado;
    }

    void MoverSelecao()
    {
        if (Input.GetButtonDown("Down") || Input.GetAxisRaw("DPad Vertical") == -1)
        {
            if (stickInUse == false)
            {
                opcaoSelecionada = MenuSelecao(menuOpcoes, opcaoSelecionada, "baixo");
                stickInUse = true;
            }
        }

        if (Input.GetButtonDown("Up") || Input.GetAxis("DPad Vertical") == 1)
        {
            if (stickInUse == false)
            {
                opcaoSelecionada = MenuSelecao(menuOpcoes, opcaoSelecionada, "cima");
                stickInUse = true;
            }
        }

        if (Input.GetAxisRaw("DPad Vertical") != 0)
        {
            stickInUse = true;
        }
        else {
            stickInUse = false;
        }

        switch (opcaoSelecionada)
        {
            case 0:
                selecao.transform.position = txtControles.transform.position;
                break;

            case 1:
                selecao.transform.position = txtVoltar.transform.position;
                break;
        }
    }

    void ConfirmarSelecao()
    {
        if (Input.GetButtonDown("X"))
        {
            if (opcaoSelecionada == 0)
            {
                SceneManager.LoadScene("MenuControles");
            }

            if (opcaoSelecionada == 1)
            {
                SceneManager.LoadScene("TelaInicial");
            }

        }
    }
}
