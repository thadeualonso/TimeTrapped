using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour {

    public Image selecao;
    public Text txtJogarNovamente;
    public Text txtSair;
    public string[] menuOpcoes;
    public int opcaoSelecionada;

    private bool stickInUse = false;

    void Awake()
    {
        menuOpcoes[0] = "Jogar Novamente";
        menuOpcoes[1] = "Sair";

        opcaoSelecionada = 0;
    }

    void Update()
    {
        MoverSelecao();
        ConfirmarSelecao();
    }

    int MenuSelecao(string[] menuItems, int itemSelecionado, string direcao)
    {
        if(direcao == "direita")
        {
            if(itemSelecionado == 0)
            {
                itemSelecionado = menuItems.Length - 1;
            }
            else
            {
                itemSelecionado -= 1;
            }
        }

        if (direcao == "esquerda")
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
        if (Input.GetButtonDown("Right") || Input.GetAxisRaw("DPad Vertical") == -1)
        {
            if (stickInUse == false)
            {
                opcaoSelecionada = MenuSelecao(menuOpcoes, opcaoSelecionada, "direita");
                stickInUse = true;
            }
        }

        if (Input.GetButtonDown("Left") || Input.GetAxis("DPad Vertical") == 1)
        {
            if (stickInUse == false)
            {
                opcaoSelecionada = MenuSelecao(menuOpcoes, opcaoSelecionada, "esquerda");
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
                selecao.transform.position = txtJogarNovamente.transform.position;
                break;
        
            case 1:
                selecao.transform.position = txtSair.transform.position;
                break;
        }
    }

    void ConfirmarSelecao()
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
