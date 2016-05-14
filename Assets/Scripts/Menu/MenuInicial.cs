using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicial : Menu
{
    public AudioClip confirmaSFX;
    public AudioClip bgmGainGround;
    public AudioManager audioManager;

    new void Awake()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    public override void ConfirmarSelecao()
    {
        if (Input.GetButtonDown("A"))
        {
            audioManager.Play(confirmaSFX);

            if (opcaoSelecionada == 0)
            {
                audioManager.Play(bgmGainGround);
                SceneManager.LoadScene("TelaJogo");
            }

            if (opcaoSelecionada == 1)
            {
                SceneManager.LoadScene("MenuOpcoes");
            }

            if (opcaoSelecionada == 2)
            {
                Application.Quit();
            }
        }
    }

}