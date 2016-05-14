using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Menu : MonoBehaviour {

    public Image selecao;
    public GameObject[] menuOpcoes;
    public int opcaoSelecionada;
    public bool menuVertical;
    public float horizontal;
    public float vertical;
    public InputManager inputManager;

    public bool stickInUse = false;

    public void Awake()
    {
        if (FindObjectOfType<InputManager>() != null)
        {
            inputManager = FindObjectOfType<InputManager>();
        }
        else
        {
            Debug.LogWarning("InputManager não encontrado");
        }

        opcaoSelecionada = 0;
    }

    public void Update()
    {
        if (inputManager == null)
        {
            inputManager = FindObjectOfType<InputManager>();
        }

        horizontal = inputManager.horizontal;
        vertical = inputManager.vertical;

        MoverSelecao();
        ConfirmarSelecao();
    }

    public int MenuSelecao(GameObject[] menuItems, int itemSelecionado, string direcao)
    {
        if (direcao == "cima" || direcao == "direita")
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

        if (direcao == "baixo" || direcao == "esquerda")
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

    public void MoverSelecao()
    {
        if (menuVertical)
        {
            if (vertical <= -0.1f)
            {
                if (stickInUse == false)
                {
                    opcaoSelecionada = MenuSelecao(menuOpcoes, opcaoSelecionada, "baixo");
                    stickInUse = true;
                }
            }

            if (vertical >= 0.1f)
            {
                if (stickInUse == false)
                {
                    opcaoSelecionada = MenuSelecao(menuOpcoes, opcaoSelecionada, "cima");
                    stickInUse = true;
                }
            }
        }
        else
        {
            if (horizontal <= -0.1f)
            {
                if (stickInUse == false)
                {
                    opcaoSelecionada = MenuSelecao(menuOpcoes, opcaoSelecionada, "esquerda");
                    stickInUse = true;
                }
            }

            if (horizontal >= 0.1f)
            {
                if (stickInUse == false)
                {
                    opcaoSelecionada = MenuSelecao(menuOpcoes, opcaoSelecionada, "direita");
                    stickInUse = true;
                }
            }
        }
   
        if (vertical != 0f || horizontal != 0f)
        {
            stickInUse = true;
        }
        else
        {
            stickInUse = false;
        }

        switch (opcaoSelecionada)
        {
            case 0:
                selecao.transform.position = menuOpcoes[0].transform.position;
                break;

            case 1:
                selecao.transform.position = menuOpcoes[1].transform.position;
                break;

            case 2:
                selecao.transform.position = menuOpcoes[2].transform.position;
                break;
        }
    }

    public abstract void ConfirmarSelecao();
}
